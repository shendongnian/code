    public static void ElementalGetRequest(String url, String md5url, String elementalUser, String elementalApiKey, out String Result)
    {
        TimeSpan t = (DateTime.UtcNow.AddSeconds(30) - new DateTime(1970, 1, 1));
        int timestamp = (int)t.TotalSeconds;
        string hash = CalculateMD5Hash(elementalApiKey + (CalculateMD5Hash(md5url + elementalUser + elementalApiKey + Convert.ToString(timestamp))));
        
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        httpWebRequest.ContentType = "application/xml";
        httpWebRequest.Accept = "application/xml";
        httpWebRequest.Method = "POST";
        httpWebRequest.Headers.Add("X-Auth-User: "+elementalUser);
        httpWebRequest.Headers.Add("X-Auth-Expires: " + Convert.ToString(timestamp));
        httpWebRequest.Headers.Add("X-Auth-Key: " + hash);
        WebResponse response = httpWebRequest.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        string serverResponse = reader.ReadToEnd();
        reader.Close();
        dataStream.Close();
        response.Close();
        Result = serverResponse;
    }
