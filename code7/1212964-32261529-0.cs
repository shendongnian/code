    private string GetPlainText(WebBrowser webBrowser)
    {
        StringBuilder sb = new StringBuilder();
         // Pick out a heading.
        foreach (HtmlElement h1 in webBrowser.Document.GetElementsByTagName("H1"))
            sb.Append(h1.InnerText + ". ");
 
        // Select only some text, ignoring everything else.
        foreach (HtmlElement div in webBrowser.Document.GetElementsByTagName("DIV"))
            if (div.GetAttribute("classname") == "story-body")
                foreach (HtmlElement p in div.GetElementsByTagName("P"))
                {
                  string classname = p.GetAttribute("classname");
                  if (classname == "introduction" || classname == "") sb.Append(p.InnerText + " ");
                }
        return sb.ToString();
      }
    }
