    var elements = browser.Document.GetElementsByTagName("span");
    foreach (HtmlElement element in elements)
    {
        // If there's more than one button, you can check the
        //element.InnerHTML to see if it's the one you want
        if (element.InnerHtml != null && element.InnerHtml.Contains("Login"))
        {
            element.InvokeMember("click");
        }
    }
