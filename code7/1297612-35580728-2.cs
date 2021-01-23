    // Your Main Library Project
    //////////////////////////////////////////////////////////////////////
    [ContractClass(typeof(ContractStockDataProvider))]
    public interface IStockDataProvider
    {
        /// <summary>
        /// Collect stock data from cache/ persistence layer/ api
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        Task<Stock> GetStockAsync(string symbol);
        /// <summary>
        /// Reset the stock history values for the specified date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task UpdateStockValuesAsync(DateTime date);
        /// <summary>
        /// Updates the stock prices with the latest values in the StockHistories table.
        /// </summary>
        /// <returns></returns>
        Task UpdateStockPricesAsync();
        /// <summary>
        /// Determines the last population date from the StockHistories table, and 
        /// updates the table with everything available after that.
        /// </summary>
        /// <returns></returns>
        Task BringStockHistoryCurrentAsync();
        event Action<StockEventArgs> OnFeedComplete;
        event Action<StockEventArgs> OnFeedError;
    }
    // Contract classes should:
    //    1. Be Private Abstract classes
    //    2. Have method implementations that always
    //       'throw new NotImplementedException()' after the contracts
    //
    [ContractClassFor(typeof (IStockDataProvider))]
    private abstract class ContractStockDataProvider : IStockDataProvider
    {
        public event Action<StockEventArgs> OnFeedComplete;
        public event Action<StockEventArgs> OnFeedError;
        public Task BringStockHistoryCurrentAsync()
        {
            // If this method doesn't mutate state in the class,
            // consider marking it with the [Pure] attribute.
            //return default(Task);
            throw new NotImplementedException();
        }
        public Task<Stock> GetStockAsync(string symbol)
        {
            Contract.Requires<ArgumentException>(
                !string.IsNullOrWhiteSpace(symbol),
                "symbol required.");
            Contract.Requires<ArgumentException>(
                symbol.Equals(symbol.ToUpperInvariant(), 
                    StringComparison.InvariantCulture),
                "symbol must be in uppercase.");
            //return default(Task<Stock>);
            throw new NotImplementedException();
        }
        public Task UpdateStockPricesAsync()
        {
            // If this method doesn't mutate state within
            // the class, consider marking it [Pure].
            //return default(Task);
            throw new NotImplementedException();
        }
        public Task UpdateStockValuesAsync(DateTime date)
        {
            Contract.Requires<ArgumentOutOfRangeException>(date <= DateTime.Today, 
                "date cannot be in the future.");
            //return default(Task);
            throw new NotImplementedException();
        }
    }
    // YOUR NEW STUBS PROJECT
    /////////////////////////////////////////////////////////////////
    using YourNamespaceWithInterface;
    // To make things simpler, use the same namespace as your interface,
    // but put '.Stubs' on the end of it.
    namespace YourNamespaceWithInterface.Stubs
    {
        // Again, this is a stub--it doesn't have to do anything
        // useful. So, if you're not going to use this stub for
        // checking logic and only use it for contract condition
        // checking, it's OK to return null--as you're not actually
        // depending on the return values of methods (unless you
        // have Contract.Ensures(bool condition) on any methods--
        // in which case, it will matter).
        public class StockDataProviderStub : IStockDataProvider
        {
            public Task BringStockHistoryCurrentAsync()
            {
                return null;
            }
            public Task<Stock> GetStockAsync(string symbol)
            {
                Contract.Requires<ArgumentException>(
                    !string.IsNullOrWhiteSpace(symbol),
                    "symbol required.");
                Contract.Requires<ArgumentException>(
                    symbol.Equals(symbol.ToUpperInvariant(), 
                        StringComparison.InvariantCulture),
                    "symbol must be in uppercase.");
                return null;
            }
            public Task UpdateStockPricesAsync()
            {
                return null;
            }
            public Task UpdateStockValuesAsync(DateTime date)
            {
                Contract.Requires<ArgumentOutOfRangeException>(
                    date <= DateTime.Today, 
                    "date cannot be in the future.");
                return null;
            }
        }
    }
    // IN YOUR UNIT TEST PROJECT
    //////////////////////////////////////////////////////////////////
    using YourNamespaceWithInteface.Stubs
    [TestClass]
    public class StockDataProviderTests
    {
        private IStockDataProvider _stockDataProvider;
        [TestInitialize]
        public void Initialize()
        {
            _stockDataProvider = new StockDataProviderStub();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task GetStockAsyncSymbolEmptyThrowsArgumentException() 
        {
            //act
            await provider.GetStockAsync(string.Empty);
            //assert
            Assert.Fail("Should have thrown ArgumentException");
        }
    }
