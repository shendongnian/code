    List<kw> header = new List<kw>();
    using (WebClient client = new WebClient())
    {
        client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
        string result = client.DownloadString(parms);
        string unescapedJson = JsonConvert.DeserializeObject<string>(result);
        header = JsonConvert.DeserializeObject<List<kw>>(unescapedJson);
    }
