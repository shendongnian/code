    public static void AddAuthorizationHeader(ref HttpWebRequest request)
    {
        string username = //load value from web.config
        string password = //load value from web.config
        string encoded = Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
    request.Headers.Add("Authorization", "Basic " + encoded);
    }
