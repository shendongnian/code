        [TestMethod]
        public void SetMethodStoresValueInInnerCache()
        {
            Mock<ObjectCache> mock = new Mock<ObjectCache>();
            MyCache<object> instance = new MyCache<object>(mock.Object);
            // Add value to mocked cache
            instance.Set(TEST_KEY, TEST_VALUE, TEST_EXPIRATION);
            mock.Verify(x => x.Set(TEST_KEY, TEST_VALUE, It.IsAny<DateTimeOffset>(), It.IsAny<string>()), Times.Once);
        }
