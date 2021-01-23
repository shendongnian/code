    public static List<AccountCurrencies> GetAccountCurrencies()
        {
            if (Settings.Default.APIKey == null || Settings.Default.APISecret == null) return new List<AccountCurrencies>();
            var nonce = (int) (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds; // same as time() in PHP, need to integrate it
            var encoding = Encoding.UTF8;
            var urlForAuth = @"https://bittrex.com/api/v1.1/account/getbalances?apikey=" + Settings.Default.APIKey + "&nonce=" + nonce;
            var result = Gethmacsha512(encoding, Settings.Default.APISecret, urlForAuth);
        // some var for the request
        var account = new List<AccountCurrencies>();
        // sending it to get the response
        var request = (HttpWebRequest)WebRequest.Create(urlForAuth);
        request.Headers.Add("apisign",result);
        //request.Headers.Add("nonce", nonce.ToString());
        request.ContentType = "application/json";
        var response = (HttpWebResponse)request.GetResponse();
        var stream = response.GetResponseStream();
        
        Resp.GetValue(stream, account);
        return account;
    }
    private static string Gethmacsha512(Encoding encoding, string apiSecret, string url)
    {
        // doing the encoding
        var keyByte = encoding.GetBytes(apiSecret);
        string result;
        using (var hmacsha512 = new HMACSHA512(keyByte))
        {
            hmacsha512.ComputeHash(encoding.GetBytes(url));
            result = ByteToString(hmacsha512.Hash);
        }
        return result;
    }
    static string ByteToString(IEnumerable<byte> buff)
    {
        return buff.Aggregate("", (current, t) => current + t.ToString("X2"));
    }
