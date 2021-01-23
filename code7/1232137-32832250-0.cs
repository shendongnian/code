    public static string GetUserDataFromYahoo(string requestEndPoint, string token, string tokenSecret)
    {
        var data = String.Empty;
        var uri = new Uri(requestEndPoint);
        string url, param;
        var oAuth = new OAuthBase();
        var nonce = oAuth.GenerateNonce();
        var timeStamp = oAuth.GenerateTimeStamp();
        var signature = oAuth.GenerateSignature(
            uri, 
            consumerKey,
            consumerSecret,
            token,
            tokenSecret, 
            "GET", 
            timeStamp, 
            nonce,
            OAuthBase.SignatureTypes.HMACSHA1, 
            out url, 
            out param);
        data = String.Format("{0}?{1}&oauth_signature={2}", url, param, signature);
        var requestParametersUrl = String.Format("{0}?{1}&oauth_signature={2}", url, param, signature);
        var request = WebRequest.Create(requestParametersUrl);
        using (var response = request.GetResponse())
        using (Stream dataStream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(dataStream))
        {
            data = reader.ReadToEnd();
        }
        return data;
    }
