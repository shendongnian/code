    #region
    
    using System;
    using System.Globalization;
    using System.Linq;
    using NUnit.Framework;
    
    #endregion
    
    namespace UnitTestProject1
    {
        [TestFixture]
        public class UnitTest1
        {
            [TestCase("2015-12-31", true)]
            [TestCase("2015-01-01", true)]
            [TestCase("2015-02-01", false)]
            [TestCase("2015-12-31 12:15:00+01:00", true)]
            [TestCase("4.3.2015", false)]
            [TestCase("4.13.2015", true)]
            [TestCase("13.13.2015", null, ExpectedException = typeof (InvalidOperationException))]
            public void TestMethod1(string input, bool expected)
            {
                Assert.AreEqual(input.DateIsLikelyNotAmbigous(), expected);
            }
        }
    
        public static class Extensions
        {
            public static bool DateIsLikelyNotAmbigous(this string stringDateTime)
            {
                return CultureInfo.GetCultures(CultureTypes.AllCultures).AsParallel().Select(ci =>
                {
                    DateTime parsed = default(DateTime);
                    bool success = DateTime.TryParse(stringDateTime, ci, DateTimeStyles.AssumeLocal, out parsed);
                    if (!success)
                        return -1;
                    if (parsed.Day > 12 || parsed.Day == parsed.Month)
                        return 1;
                    return 0;
                }).Where(w => w >= 0).Average(a => a) > 0.02;
            }
        }
    }
