     public class ShortTextService
    {
        private string _baseUrl =
            "https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exlimit=max&explaintext&exintro&titles={0}&redirects=";
        public string GetShortText(string name)
        {
            string requestUrl = string.Format(_baseUrl, name);
            string result;
            using (WebClient client = new WebClient())
            {
                try
                {
                    string response = client.DownloadString(requestUrl);
                    RootObject responseJson = JsonConvert.DeserializeObject<RootObject>(response);
                   
                    var firstKey = responseJson.query.pages.First().Key;
                    var extract = responseJson.query.pages[firstKey].extract;
                    Regex regex = new Regex(@".(?<=\()[^()]*(?=\)).(.)");
                    extract = regex.Replace(extract, string.Empty);
                    result = Regex.Replace(extract, @"\\n", " ");
                }
                catch (Exception)
                {
                    result = "Error";
                    //handle exception here. E.g Logging
                }
            }
            return result;
        }
    }
