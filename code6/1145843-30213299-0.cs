    HtmlElement table =  testWebBrowser.Document.GetElementById("TableID");
    if (table != null)
    {
        foreach (HtmlElement row in table.GetElementsByTagName("TR"))
        {
            // ...
        }
    }
