     [TestClass]
    public class CacheWrapperTest
    {
        private DataAccessTestStub _dataAccessTestClass;
        [TestInitialize]
        public void Init()
        {
            _dataAccessTestClass = new DataAccessTestStub(new CacheWrapper());
        }
        [TestMethod]
        public void GetFromCache_ShouldExecuteCacheMissCall()
        {
            var original = _dataAccessTestClass.GetDateTimeTicks();
            Assert.IsNotNull(original);
        }
        [TestMethod]
        public void GetFromCache_ShouldReturnCachedVersion()
        {
            var copy1 = _dataAccessTestClass.GetDateTimeTicks();
            var copy2 = _dataAccessTestClass.GetDateTimeTicks();
            Assert.AreEqual(copy1, copy2);
        }
        [TestMethod]
        public void GetFromCache_ShouldRespectTimeToLive()
        {
            _dataAccessTestClass.ClearDateTimeTicks();
            var copy1 = _dataAccessTestClass.GetDateTimeTicks(TimeSpan.FromSeconds(2));
            var copy2 = _dataAccessTestClass.GetDateTimeTicks();
            Assert.AreEqual(copy1, copy2);
            Thread.Sleep(3000);
            var copy3 = _dataAccessTestClass.GetDateTimeTicks();
            Assert.AreNotEqual(copy1, copy3);
        }
        [TestMethod]
        public void InvalidateCache_ShouldClearCachedVersion()
        {
            var original = _dataAccessTestClass.GetDateTimeTicks();
            _dataAccessTestClass.ClearDateTimeTicks();
            var updatedVersion = _dataAccessTestClass.GetDateTimeTicks();
            Assert.AreNotEqual(original, updatedVersion);
        }
    }
