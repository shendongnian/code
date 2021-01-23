    public class CookieAwareWebClient : WebClient
    {
        public CookieCollection Cookies = new CookieCollection();
        private void AddCookiesTo(HttpWebRequest request)
        {
            if (Cookies != null && Cookies.Count > 0)
            {
                request.CookieContainer.Add(Cookies);
            }
        }
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            HttpWebRequest webRequest = request as HttpWebRequest;
            if (webRequest != null)
            {
                if (webRequest.CookieContainer == null) webRequest.CookieContainer = new CookieContainer();
                AddCookiesTo(webRequest);
            }
            return request;
        }
    }
