    static void DownloadPage()
    {
        CookieContainer cookies = new CookieContainer();
        HttpClientHandler handler = new HttpClientHandler();
        handler.CookieContainer = cookies;
        using (HttpClient client = new HttpClient(handler))
        {
            using (HttpResponseMessage response = client.GetAsync("https://www.kijiji.ca/t-login.html").Result)
            {
                HttpHeaders headers = response.Headers;
                HttpContent content = response.Content;
                string myContent = content.ReadAsStringAsync().Result;
                // Find value of ASOtherLang.
                //  It's in this pattern:
                //  <input type="hidden" id="ASOtherLang" value="fr_CA"/>
                Regex regex = new Regex("id=\"ASOtherLang\" value=\"(.*)\"");
                var otherLang = regex.Match(myContent).Groups[1];
                Console.WriteLine(otherLang);
            }
        }
    }
