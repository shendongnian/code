    var items = webBrowser1.Document.GetElementsByTagName("span");
    foreach (HtmlElement item in items)
    {
        if (item.GetAttribute("className") == "validationMsg")
        {
            // Now you can check the item's value by comparing item.InnerText
        }
    }
