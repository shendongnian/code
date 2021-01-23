    [TestClass]
    public class PageableTests
    {
        private int[] _data;
        [TestInitialize]
        public void SetUp()
        {
            var initialData = new List<int>();
            for (var i = 1; i < 136; i++)
                initialData.Add(i);
            _data = initialData.ToArray();
        }
        [TestMethod]
        public void CanPageNext()
        {
            var testData = new Pageable<int>(_data);
            var firstPage = testData.GetCurrentPage().ToList();
            Assert.AreEqual(1, firstPage.First());
            Assert.AreEqual(10, firstPage.Last());
            var secondPage = testData.NextPage().ToList();
            Assert.AreEqual(11, secondPage.First());
            Assert.AreEqual(20, secondPage.Last());
        }
        [TestMethod]
        public void ReturnsFirstPageWhenPageIsNegative()
        {
            var testData = new Pageable<int>(_data);
            var firstPage = testData.GetCurrentPage().ToList();
            Assert.AreEqual(1, firstPage.First());
            Assert.AreEqual(10, firstPage.Last());
            var secondPage = testData.PreviousPage().ToList();
            Assert.AreEqual(1, secondPage.First());
            Assert.AreEqual(10, secondPage.Last());
            var thirdPage = testData.PreviousPage().ToList();
            Assert.AreEqual(1, thirdPage.First());
            Assert.AreEqual(10, thirdPage.Last());
        }
        [TestMethod]
        public void CanPreviousPage()
        {
            var testData = new Pageable<int>(_data);
            var firstPage = testData.GetCurrentPage().ToList();
            Assert.AreEqual(1, firstPage.First());
            Assert.AreEqual(10, firstPage.Last());
            var secondPage = testData.NextPage().ToList();
            Assert.AreEqual(11, secondPage.First());
            Assert.AreEqual(20, secondPage.Last());
            testData.NextPage();
            var thirdPage = testData.PreviousPage().ToList();
            Assert.AreEqual(secondPage.First(), thirdPage.First());
            Assert.AreEqual(secondPage.Last(), thirdPage.Last());
            var fourthPage = testData.PreviousPage().ToList();
            Assert.AreEqual(firstPage.First(), fourthPage.First());
            Assert.AreEqual(firstPage.Last(), fourthPage.Last());
        }
        [TestMethod]
        public void CannotExcceedMaxPages()
        {
            var testData = new Pageable<int>(_data);
            for (var i = 0; i < 20; i++)
            {
                testData.NextPage();
            }
            var lastPage = testData.GetCurrentPage().ToList();
            Assert.AreEqual(131, lastPage.First());
            Assert.AreEqual(135, lastPage.Last());
            var nextToLastPage = testData.PreviousPage();
            Assert.AreEqual(121, nextToLastPage.First());
        }
    }
