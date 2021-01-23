    public class DefCurrencyController : ApiController
    {
        [HttpGet, Route("api/currencies")]
        public List<DefCurrency> GetAllCurrencies()
        {
            return DefCurrency.AllDefCurrency;
        }
    }
