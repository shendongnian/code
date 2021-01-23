    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        // Select the html element by inner text of anchor and click on it
        HtmlElementCollection elc = this.webBrowser1.Document.GetElementsByTagName("a");
        foreach (HtmlElement el in elc)                
        {
            var hRef = el.GetAttribute("href");
            if(string.IsNullOrWhitespace(hRef))
              continue;
            var lnkUri = new Uri(hRef);
            //If the link points to this page, ignore it
            if(lnkUri.Segments[lnkUri.Segments.Length - 1] == e.Url.Segments[e.Url.Segments.Length - 1])
                continue;
            if ((el.InnerText == null || el.InnerText.Equals("Matching text"))
            {
                el.InvokeMember("click");
            }
        }
    }
