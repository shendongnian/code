    [TestClass]
    public class Class1
    {
        [TestMethod]
        public void test()
        {
            var listoflist = new List<List<string>>
            {
                new List<string> {"A", "B", "C"},
                new List<string> {"A", "B", "D", "E"}
            };
            var result = listoflist.SelectMany(l=>l).Distinct().ToList();
            Assert.AreEqual(result.Count, 5);
        }
    }
