    HtmlElementCollection classButton = webBrowser1.Document.All;
    foreach (HtmlElement element in classButton)
    {
        if (Regex.IsMatch(element.GetAttribute("class"), @"\bbutton\b"))
        {
            element.InvokeMember("click");
        }
    }
