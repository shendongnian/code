        public static class StringExtensions
        {
            public static string ReplaceAllOccurrences(
                this string str,
                string oldValue,
                string newValue)
            {
                var stringBuilder = new StringBuilder(str);
                while (stringBuilder.ToString().Contains(oldValue))
                {
                    stringBuilder.Replace(oldValue, newValue);
                }
                return stringBuilder.ToString();
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
