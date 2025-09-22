using AnalaizerClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalcTest
{
    [TestClass]
    public class AnalazierClassTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void Separate_ValidNumericAdditionString_ReturnsValidTokens()
        {
            string inputString = "111+223+19";
            List<string> expectedOutput = new List<string>() 
            { "111", "+", "223", "+", "19" };
            List<string> result = AnalaizerClass.Separate(inputString).ToList();
            CollectionAssert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void Separate_ValidNumericSubtractionString_ReturnsValidTokens()
        {
            string inputString = "-324-904-1482";
            List<string> expectedOutput = new List<string>() 
            { "-", "324", "-", "904", "-", "1482" };
            List<string> result = AnalaizerClass.Separate(inputString).ToList();
            CollectionAssert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void Separate_ValidNumericComplexString_ReturnsValidTokens()
        {
            string inputString = "17/3*(20-1/5)-100";
            List<string> expectedOutput = new List<string>()
            { "17", "/", "3", "*", "(", "20", "-", "1", "/", "5", ")", "-", "100" };
            List<string> result = AnalaizerClass.Separate(inputString).ToList();
            CollectionAssert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void Separate_ValidAlphabeticalAdditionString_ReturnsValidTokens()
        {
            string inputString = "a+b+f+d";
            List<string> expectedOutput = new List<string>() 
            { "a", "+", "b", "+", "f", "+", "d" };
            List<string> result = AnalaizerClass.Separate(inputString).ToList();
            CollectionAssert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void Separate_ValidAlphabeticalComplexString_ReturnsValidTokens()
        {
            string inputString = "h/q*(das-io/xz)-abc";
            List<string> expectedOutput = new List<string>() 
            { "h", "/", "q", "*", "(", "das", "-", "io", "/", "xz", ")", "-", "abc" };
            List<string> result = AnalaizerClass.Separate(inputString).ToList();
            CollectionAssert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void Separate_ValidComplexString_ReturnsValidTokens()
        {
            string inputString = "1+c-(2*x)/4+3*(a+b)-5";
            List<string> expectedOutput = new List<string>() 
            { "1", "+", "c", "-", "(", "2", "*", "x", ")", "/", "4", "+", "3", "*", "(", "a", "+", "b", ")", "-", "5" };
            List<string> result = AnalaizerClass.Separate(inputString).ToList();
            CollectionAssert.AreEqual(expectedOutput, result);
        }

        [DataSource("System.Data.SqlClient", 
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CalcTestDataForSeparateMethod;Integrated Security=True;Connect Timeout=30;Encrypt=False;", 
            "DataForTests", 
            DataAccessMethod.Sequential)]
        [TestMethod]
        public void Separate_ValidString_ReturnsValidTokens_FromDB()
        {
            string inputString = TestContext.DataRow["inputString"].ToString();
            List<string> expectedOutput = TestContext.DataRow["expectedOutput"].ToString().Split(',').ToList();
            List<string> result = AnalaizerClass.Separate(inputString).ToList();
            CollectionAssert.AreEqual(expectedOutput, result);
        }
    }
}
