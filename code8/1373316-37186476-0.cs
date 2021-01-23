    public class HttpClientHelper
    {
        public static HttpClient GetHttpClient()
        {
            var MyHttpClient = new HttpClient();
            dynamic _token = HttpContext.Current.Session["token"];
            if (_token == null) throw new ArgumentNullException(nameof(_token));
            MyHttpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", _token.AccessToken));
            return MyHttpClient;
        }
    }
