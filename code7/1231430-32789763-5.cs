    public class WebAPIController : Controller
    {
        public ActionResult Converter()
        {
            var currencies = new CurrenciesRepository.GetAll();
            
            var currencyModel = new CurrencyModel
            {
                Currencies =
                    currencies.Select(currency => new SelectListItem {
                                                      Text = currency.Value, 
                                                       Value = currency.Key});
            }
            return View("Index", currencyModel);
        }
    }
