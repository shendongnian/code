    private async Task GetHtmlDocument(string url)
    {
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
        request.Credentials = new LoginCredentials().Credentials;
        try
        {
            WebResponse myResponse = await request.GetResponseAsync();
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.OptionFixNestedTags = true;
            htmlDoc.Load(myResponse.GetResponseStream());
        } catch (...) { ... }
    }
