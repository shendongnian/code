        private static string Get(string url)
        {
            var webRequest = WebRequest.CreateHttp(url);
            using (var webResponse = webRequest.GetResponse())
            using (var responseStream = webResponse.GetResponseStream())
            using (var responseStreamReader = new StreamReader(responseStream, System.Text.Encoding.UTF8))
            {
                var result = responseStreamReader.ReadToEnd();
                return result;
            }
  
        }
        private static IEnumerable<string> ScrapeForLinks(string url)
        {
            var d = new HtmlAgilityPack.HtmlDocument();
            d.LoadHtml(Get(url));
            return d.DocumentNode.SelectNodes("//a[@href]")
                .Select(
                    link => link
                        .Attributes
                        .Where(a => a.Name.ToLower() == "href")
                        .Select(a => a.Value)
                        .FirstOrDefault());
        }
