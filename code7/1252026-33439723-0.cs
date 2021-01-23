    HtmlElementCollection classButton = webBrowser1.Document.All;
    foreach (HtmlElement element in classButton)
    {
        if (element.GetAttribute("class").Contains("button"))
        {
            element.InvokeMember("click");
        }
    }
