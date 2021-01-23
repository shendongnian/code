    protected HtmlElement[] GetElementsByParent(HtmlDocument document, HtmlElement baseElement = null, params string[] singleSelectors)
    {
        if (singleSelectors == null || singleSelectors.Length == 0)
        {
            throw new Exception("Please give at least 1 selector!");
        }
        IList<HtmlElement> result = new List<HtmlElement>();
        bool last = singleSelectors.Length == 1;
        string singleSelector = singleSelectors[0];
        if (string.IsNullOrWhiteSpace(singleSelector) || string.IsNullOrWhiteSpace(singleSelector.Trim()))
        {
            return null;
        }
        singleSelector = singleSelector.Trim();
        if (singleSelector.StartsWith("#"))
        {
            var item = document.GetElementById(singleSelector.Substring(1));
            if (item == null)
            {
                return null;
            }
            if (last)
            {
                result.Add(item);
            }
            else
            {
                var results = GetElementsByParent(document, item, singleSelectors.Skip(1).ToArray());
                if (results != null && results.Length > 0)
                {
                    foreach (var res in results)
                    {
                        result.Add(res);
                    }
                }
            }
        }
        else if (singleSelector.StartsWith("."))
        {
            if (baseElement == null)
            {
                baseElement = document.Body;
            }
            foreach (HtmlElement child in baseElement.Children)
            {
                string cls;
                if (!string.IsNullOrWhiteSpace((cls = child.GetAttribute("class"))))
                {
                    if (cls.Split(' ').Contains(singleSelector.Substring(1)))
                    {
                        if (last)
                        {
                            result.Add(child);
                        }
                        else
                        {
                            var results = GetElementsByParent(document, child, singleSelectors.Skip(1).ToArray());
                            if (results != null && results.Length > 0)
                            {
                                foreach (var res in results)
                                {
                                    result.Add(res);
                                }
                            }
                        }
                    }
                }
            }
        }
        else
        {
            HtmlElementCollection elements = null;
            if (baseElement != null)
            {
                elements = baseElement.GetElementsByTagName(singleSelector);
            }
            else
            {
                elements = document.GetElementsByTagName(singleSelector);
            }
            foreach (HtmlElement item in elements)
            {
                if (last)
                {
                    result.Add(item);
                }
                else
                {
                    var results = GetElementsByParent(document, item, singleSelectors.Skip(1).ToArray());
                    if (results != null && results.Length > 0)
                    {
                        foreach (var res in results)
                        {
                            result.Add(res);
                        }
                    }
                }
            }
        }
        return result.ToArray();
    }
    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        // here we can query
        var result = GetElementsByParent(webBrowser1.Document, null, "#theseImages", "img");
    }
