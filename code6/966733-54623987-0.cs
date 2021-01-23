    private static string redirectDomain = System.Configuration.ConfigurationManager.AppSettings["DomainName"];
            private string state = Guid.NewGuid().ToString();
            private static string client_id = System.Configuration.ConfigurationManager.AppSettings["O365ClientId"];
            private static string client_secret = System.Configuration.ConfigurationManager.AppSettings["O365ClientSecret"];
     public ActionResult IndexAsync(CancellationToken cancellationToken)
            {
                string url = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize?client_id="+client_id+"&response_type=code&redirect_uri=http://localhost/Controllers/o365login/callback&response_mode=query&scope=openid%20offline_access%20https%3A%2F%2Fgraph.microsoft.com%2Fmail.read&state=" + state;
                return  Redirect(url);
            }
        public async void Callback(string code,string state)
            {
                var o365UserInfo = await getO365UserInfo(code);
                if(o365UserInfo != null)
                {
                    O365user o365User =   GetEmailFromIdToken(o365UserInfo.access_token);
                    if (o365User != null)
                    {
    
                    }
                }
            }
        private async Task<O365UserInfo> getO365UserInfo(string code)
            {
                try
                {
                    string url = "https://login.microsoftonline.com/common/oauth2/v2.0/token";
                    List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
                    postData.Add(new KeyValuePair<string, string>("grant_type", "authorization_code"));
                    postData.Add(new KeyValuePair<string, string>("code", code));
                    postData.Add(new KeyValuePair<string, string>("redirect_uri", "http://localhost/Controllers/o365login/callback"));
                    postData.Add(new KeyValuePair<string, string>("client_id", client_id));
                    postData.Add(new KeyValuePair<string, string>("client_secret", client_secret));
                    using (var httpClient = new HttpClient())
                    {
                        using (var content = new FormUrlEncodedContent(postData))
                        {
                            content.Headers.Clear();
                            content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                            var req = new HttpRequestMessage(HttpMethod.Post, url) { Content = content };
                            HttpResponseMessage response = await httpClient.SendAsync(req);
                            O365UserInfo o365UserInfo= await response.Content.ReadAsAsync<O365UserInfo>();
                            return o365UserInfo;
                        }
                    }
                }catch(Exception ex)
                {
                    return null;
                }
            }
    class O365UserInfo
            {
                public string access_token { get; set; }
                public string token_type { get; set; }
                public int expires_in { get; set; }
                public string expires_on { get; set; }
                public string resource { get; set; }
                public string refresh_token { get; set; }
                public string scope { get; set; }
                public string id_token { get; set; }
            }
            class O365user
            {
                public string name { get; set; }
                public string upn { get; set; }
            }
`
