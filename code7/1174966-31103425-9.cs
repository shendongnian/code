    public class CurrencyService
    {
        private static IEnumerable<CurrencyModel> currencyRates;
        private static object ratesLock = new object();
        public IEnumerable<CurrencyModel> GetLiveExchangeRates()
        {
            if (currencyRates == null)
            {
                lock (ratesLock)
                {
                    currencyRates = GetSomeFooLiveDataFromInternet();
                }
            }
            return currencyRates;
        }
        public void ClearRates()
        {
            currencyRates = null;
        }
    }
