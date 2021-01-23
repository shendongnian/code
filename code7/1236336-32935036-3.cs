    async void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        if (e.Url.AbsoluteUri != "https://www.onegov.nsw.gov.au/PublicRegister/#/publicregister/search/Security")
            return;
        await Task.Delay(5000);
        var f = this.webBrowser1.Document.Body.All.GetElementsByName("searchForm")
                    .Cast<HtmlElement>()
                    .FirstOrDefault();
        var q = f.All.GetElementsByName("searchText")
                    .Cast<HtmlElement>()
                    .FirstOrDefault();
        q.InnerText = "123456789";
        f.InvokeMember("submit");
    }
