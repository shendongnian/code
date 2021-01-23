    using System;
    using NUnit.Framework;
    
    namespace UnitTestProject1
    {
        [TestFixture]
        public class UnitTest1
        {
            [TestCase("2015-12-31", true)]
            [TestCase("4.3.2015", false)]
            [TestCase("4.13.2015", true)]
            [TestCase("13.13.2015", false, ExpectedException = typeof(FormatException))]
            public void TestMethod1(string input, bool expected)
            {
                Assert.AreEqual(expected, input.IsDateNotAmbigous());
            }
        }
    
        public static class Extensions
        {
            public static bool IsDateNotAmbigous(this string stringDateTime)
            {
                DateTime parsed = DateTime.Parse(stringDateTime);
                return parsed.Day>12;
            }
        }
    }
