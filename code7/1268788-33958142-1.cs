    public static bool Test(string url)
    {
        
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        req.Method = "HEAD";
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        Boolean isHttpOk = resp.StatusCode == HttpStatusCode.OK;
        resp.Close();
        return isHttpOk;
            
    }
