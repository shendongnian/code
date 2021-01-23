    string theText;
    foreach (HtmlElement item in webBrowser1.Document.GetElementsByTagName("div"))
            {
                if (item.GetAttribute("className") == "content")
                    theText = item.GetElementsByTagName("b")[0].InnerText;
            }
