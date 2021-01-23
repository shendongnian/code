    HtmlElement FindHtmlElement(string tag, Predicate<HtmlElement> predicate)
    {
        try
        {            
            var elements = webBrowser1.Document.GetElementsByTagName(tag);
            foreach (HtmlElement element in elements)
            {
                if (predicate(element))
                {
                    return element;
                }
            }
        }
        catch (Exception ex)
        {
            //Log.Error("Error on finding html element on {0}. Exception: {1}", _webBrowserBot.Url.ToString(), ex.Message);
        }
        
        return null;
    
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        // search for <cite class="_Rm">www.dicksmith.com.au/apple-<b>ipad</b></cite>
        var element = FindHtmlElement("cite", (h) =>
        {
            return h.GetAttribute("class") == "_Rm";               
        });
    
        string url = "";
        if (element != null)
        {
            // retrieve url only
            int ix = element.InnerHtml.IndexOf("-<b>");
            if (ix > 0)
                url = element.InnerHtml.Remove(ix);
    
            // url obtained
            //...
        }
    }
