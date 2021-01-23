    webBrowser.DocumentCompleted += (s, e) =>
    {
        var links = webWebBrowser.Document.GetElementById("n6");
        String tmp = links.InnerText;
    };
    webWebBrowser.Navigate(url);
