    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void StringFromListIsFoundInString()
        {
            var listOfString = new List<string>() {"test", "bigword", "sillyword"};
            var stringToSearch = "this is a test";
            Assert.That(stringToSearch.HasAnyElementsOfList(listOfString), Is.EqualTo(true));
        }        
    }
    public static class MyStringExtensions
    {
        public static bool HasAnyElementsOfList(this string stringToSearch, List<string> listOfStrings)
        {
            return listOfStrings.Any(listString => stringToSearch.Contains(listString));
        }
    }
