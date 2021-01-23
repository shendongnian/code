        private static string Get(int msBetweenRequests, string url)
        {
            try
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
            catch
            {
                return null; // really nothing sensible to do here
            }
            finally
            {
                // let's be nice to the server we're crawling
                System.Threading.Thread.Sleep(msBetweenRequests);
            }
        }
        private static IEnumerable<string> ScrapeForLinks(string url)
        {
            var noResults = Enumerable.Empty<string>();
            var html = Get(1000, url);
            if (string.IsNullOrWhiteSpace(html)) return noResults;
            var d = new HtmlAgilityPack.HtmlDocument();
            d.LoadHtml(html);
            var links = d.DocumentNode.SelectNodes("//a[@href]");
            return links == null ? noResults :
                links.Select(
                    link => 
                        link
                        .Attributes
                        .Where(a => a.Name.ToLower() == "href")
                        .Select(a => a.Value)
                        .First()
                 )
                 .Select(linkUrl => FixRelativePaths(url, linkUrl))
                        ;
        }
        private static string FixRelativePaths(string baseUrl, string relativeUrl)
        {
            var combined = new Uri(new Uri(baseUrl), relativeUrl);
            return combined.ToString();
        }
