    namespace ConsoleApplication10
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<string> exchangeRate = new List<string>();
                string BSE = "USD";
                string URL = "http://api.fixer.io/latest?base=" + BSE;
    
                using (var webClient = new System.Net.WebClient())
                {
                    var json = webClient.DownloadString(URL);
                    dynamic stuff = JsonConvert.DeserializeObject(json);
    
                    foreach (JProperty item in stuff)
                    {
                        if (item.Name == "rates")
    
                        {
                            exchangeRate.AddRange(from rate in item from xch in rate select xch.ToString());
                            foreach (var value in exchangeRate)
                            {
                                Console.WriteLine(value);
                            }
                        }
                    }
                }
    
            }
        }
    }
