        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetStockAsyncSymbolEmptyThrowsArgumentException1()
        {
            //arrange
            var sut = new Mock<ContractStockDataProvider>();
            //act
            sut.Object.GetStockAsync(string.Empty);
        }
