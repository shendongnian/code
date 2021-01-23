    [TestClass]
    public class UnitTest1
    {
        Test t;
        [TestInitialize]
        public void TestInitialize()
        {
            t = new Test();
        }
        [TestMethod]
        public void TestGetBooksByGenre()
        {
            var result = t.Search(new List<int>()
            {
                1
            });
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0].Id == 1);
        }
    }
