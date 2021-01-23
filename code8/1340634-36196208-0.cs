        public void WebsiteCall(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = container;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            container = request.CookieContainer;
        }
