      private ArrayList GetEmailContacts() {
        OAuthBase oauth = new OAuthBase();
        Uri uri = new Uri("https://social.yahooapis.com/v1/user/" + OauthYahooGuid + "/contacts?format=XML");
        string nonce = oauth.GenerateNonce();
        string timeStamp = oauth.GenerateTimeStamp();
        string normalizedUrl;
        string normalizedRequestParameters;
        string sig = oauth.GenerateSignature(uri, this.sConsumerKey, this.sConsumerSecret, OauthToken, OauthTokenSecret, "GET", timeStamp, nonce, OAuthBase.SignatureTypes.HMACSHA1, out normalizedUrl, out normalizedRequestParameters);
        StringBuilder sbGetContacts = new StringBuilder(uri.ToString());
        try {
        string returnStr = string.Empty;
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(sbGetContacts.ToString());
        req.Accept = "application/xml";
        req.Method = "GET";
        ArrayList emails = new ArrayList();
        string authHeader = "Authorization: OAuth " +
        "realm=\"yahooapis.com\"" +
        ",oauth_consumer_key=\"" + this.sConsumerKey + "\"" +
        ",oauth_nonce=\"" + nonce + "\"" +
        ",oauth_signature_method=\"HMAC-SHA1\"" +
        ",oauth_timestamp=\"" + timeStamp + "\"" +
        ",oauth_token=\"" + OauthToken + "\"" +
        ",oauth_version=\"1.0\"" +
        ",oauth_signature=\"" + HttpUtility.UrlEncode(sig) + "\"";
        req.Headers.Add(authHeader);
        using (HttpWebResponse res = (HttpWebResponse)req.GetResponse()) {
