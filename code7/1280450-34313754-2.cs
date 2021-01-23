        public static class StringExtensions
        {
            public static string ReplaceAllOccurrences(
                this string str,
                string oldValue,
                string newValue)
            {
                var result = str;
                while (result.Contains(oldValue))
                {
                    result = result.Replace(oldValue, newValue);
                }
                return result;
            }
        }
        [TestClass]
        public class ReplaceAllOccurencesTest
        {
            [TestMethod]
            public void Test()
            {
                var userData = "----";
                var replaced = userData.ReplaceAllOccurrences("--", "- -"); // returns "- -- -", I expected "- - - -"
                Assert.AreEqual(replaced, "- - - -");
                userData = "---";
                replaced = userData.ReplaceAllOccurrences("--", "- -"); // returns "- --", I expected "- - -"
                Assert.AreEqual(replaced, "- - -");
            }
        }
