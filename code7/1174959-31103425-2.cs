    public class MyController
    {
        private IEnumerable<CurrencyModel> currentRates;
        public MyController()
        {
            // Instance a new service; or provide it through the constructor as a dependency
            var currencyService = new CurrencyService();
            this.currentRates = currencyService.GetLiveExchangeRates();
        }
    }
