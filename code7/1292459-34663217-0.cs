    private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        try
        {
            mainDoc = webBrowser.Document;
            if (mainDoc != null)
            {
                HtmlElementCollection heads = mainDoc.GetElementsByTagName("head");
                HtmlElement scriptEl = mainDoc.CreateElement("script");
                IHTMLScriptElement el = (IHTMLScriptElement)scriptEl.DomElement;
                el.text = "alert('hello world')";
                heads[0].AppendChild(scriptEl);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());
        }
    }
