    public abstract class ContractStockDataProvider
    {
        public void GetStockAsync(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException();
            }
        }
     }
