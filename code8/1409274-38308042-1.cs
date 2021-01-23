    public class MyClient : WebClient
    {
        private readonly CookieContainer _container = new CookieContainer();
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
            if (request == null)
                throw new InvalidOperationException("request == null");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.CookieContainer = this._container;
            ... // Add Required Cookies Here?
            Uri target = new Uri("http://example.com");
            this._container.Add(new Cookie("_spc", "aefec0ba-dc10-23e5-46f1-6b6e50c8837e") { Domain = target.Host }); 
            return request;
        }
    }
