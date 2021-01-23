    [TestClass]
    public class StockDataProviderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetStockAsyncSymbolEmptyThrowsArgumentException()
        {
            //arrange
            var sut = new StubContractStockDataProvider();
            //act
            sut.GetStockAsync(string.Empty);
        }
        public class StubContractStockDataProvider : ContractStockDataProvider
        {
        }
    }
