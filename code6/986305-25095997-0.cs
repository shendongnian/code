    using System;
    using System.Collections.Specialized;
    using System.Net;
    using System.Text;
    
    namespace Instagram
    {
        public class InstagramClient
        {
            public InstagramClient(string code)
            {
                GetToken(code);
            }
    
            private void GetToken(string code)
            {
                using (var wb = new WebClient())
                {
                    var parameters = new NameValueCollection
                                     {
                                         {"client_id", "ClientId"},
                                         {"client_secret", "ClientSecret"},
                                         {"grant_type", "authorization_code"},
                                         {"redirect_uri", "RedirectUri"},
                                         {"code", code}
                                     };
    
                    var response = wb.UploadValues("https://api.instagram.com/oauth/access_token", "POST", parameters);
                    string json = Encoding.ASCII.GetString(response);
    
                    try
                    {
                        var OauthResponse = (InstagramOAuthResponse)    Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(InstagramOAuthResponse));
                    }
                    catch (Exception ex)
                    {
                        //handle ex if needed.
                    }
                }
            }
    
            public class InstagramOAuthResponse
            {
                public string access_token { get; set; }
                public User user { get; set; }
            }
    
            public class User : System.Security.Principal.IIdentity
            {
                public string username { get; set; }
                public string website { get; set; }
                public string profile_picture { get; set; }
                public string full_name { get; set; }
                public string bio { get; set; }
                public string id { get; set; }
    
                public string OAuthToken { get; set; }
    
                public string AuthenticationType
                {
                    get { return "Instagram"; }
                }
    
                public bool IsAuthenticated
                {
                    get { return !string.IsNullOrEmpty(id); }
                }
    
                public string Name
                {
                    get
                    {
                        return String.IsNullOrEmpty(full_name) ? "unknown" : full_name;
                    }
                }
            }
        }
    }
