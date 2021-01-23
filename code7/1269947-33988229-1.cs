    string url = "http://9gag.com/report-post";
    string parameters = "entryId=aKBQ00O&type=4&link=";
    using (WebClient wc = new WebClient())
    {
        wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
        string HtmlResult = wc.UploadString(url,  parameters);
        Console.WriteLine(HtmlResult);
    }
