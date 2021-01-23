    string url = "http://9gag.com/gag/aKBQ00O";
    string parameters = "radio-report=1";
    using (WebClient wc = new WebClient())
    {
        wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
        string HtmlResult = wc.DownloadString(url + "?" + parameters);
        Console.WriteLine(HtmlResult);
    }
