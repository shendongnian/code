    public class CurrenciesRepository
    {
        string _url = "http://openexchangerates.org/api/currencies.json";
        
        public IDictionary<string, string> GetAll()
        {
            using (var webClient = new WebClient())
            {
                var data = webClient.DownloadString(_url);
                var currencies= JsonConvert.DeserializeObject<Dictionary<string,string>>(data);
                return currencies;
            }
        }
    }
