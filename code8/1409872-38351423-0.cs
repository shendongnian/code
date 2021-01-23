    private static OAuth2AccessTokenResponse IssueToken(string sts, OAuth2AccessTokenRequest oauth2Request) {
        string requestString = "grant_type=" + System.Web.HttpUtility.UrlEncode(oauth2Request.GrantType) +
                                "&client_id=" + System.Web.HttpUtility.UrlEncode(oauth2Request.ClientId) +
                                "&client_secret=" + System.Web.HttpUtility.UrlEncode(oauth2Request.ClientSecret) +
                                "&resource=" + System.Web.HttpUtility.UrlEncode(oauth2Request.Resource);
                                
        string tokenResponse;
        byte[] byteArray = Encoding.UTF8.GetBytes(requestString);
        WebRequest request = WebRequest.Create(sts);
        request.Proxy = new System.Net.WebProxy { Address = new Uri(InternetProxy) };
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = byteArray.Length;
        using (Stream reqStream = request.GetRequestStream()) {
            reqStream.Write(byteArray, 0, byteArray.Length);
        }
        using (WebResponse response = request.GetResponse()) {
            using (Stream respStream = response.GetResponseStream()) {
                using (StreamReader reader = new StreamReader(respStream)) {
                    tokenResponse = reader.ReadToEnd();
                }
            }
        }
        
        JavaScriptSerializer jss = new JavaScriptSerializer();
        OAuth2AccessTokenResponseDummy dummy = jss.Deserialize<OAuth2AccessTokenResponseDummy>(tokenResponse);
        OAuth2AccessTokenResponse oauth2Response = new OAuth2AccessTokenResponse () {
            TokenType = dummy.token_type,
            ExpiresIn = dummy.expires_in,
            NotBefore = jss.Deserialize<DateTime>(@"""\/Date(" + dummy.not_before + @")\/""").ToLocalTime(),
            ExpiresOn = jss.Deserialize<DateTime>(@"""\/Date(" + dummy.expires_on + @")\/""").ToLocalTime(),
            Scope = dummy.resource,
            AccessToken = dummy.access_token
        };
        return oauth2Response;
    }
    private class OAuth2AccessTokenResponseDummy {
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string not_before { get; set; }
        public string expires_on { get; set; }
        public string resource { get; set; }
        public string access_token { get; set; }
    }
