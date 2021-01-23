    public class AWeber
        {
            public void Authorize()
            {
                var Session = HttpContext.Current.Session;
                var api = new API(AppSettings.AWebberConsumerKey, AppSettings.AWebberConsumerSecret);
                api.CallbackUrl = "http://localhost:61006/test.aspx"; 
                api.get_request_token();
                Session["OAuthToken"] = api.OAuthToken;
                Session["OAuthTokenSecret"] = api.OAuthTokenSecret;
    
                api.authorize();
            }
    
            public void InitAccessToken(string OAuthVerifier)
            {
                var Session = HttpContext.Current.Session;
                var api = new API(AppSettings.AWebberConsumerKey, AppSettings.AWebberConsumerSecret);
                api.OAuthToken = (string)Session["OAuthToken"];
                api.OAuthTokenSecret = (string)Session["OAuthTokenSecret"];
                api.OAuthVerifier = OAuthVerifier;
    
                Session["OAuthToken"] = api.get_access_token();
                Session["OAuthTokenSecret"] = api.adapter.OAuthTokenSecret;
    
                var account = api.getAccount();
            }
    
            public void GetData()
            {
                var Session = HttpContext.Current.Session;
                var api = new API(AppSettings.AWebberConsumerKey, AppSettings.AWebberConsumerSecret);
    
                api.adapter.OAuthToken = (string)Session["OAuthToken"];
                api.adapter.OAuthTokenSecret = (string)Session["OAuthTokenSecret"];
                Account account = api.getAccount();       
            }
        }
