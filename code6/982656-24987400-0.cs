    var buttons = webBrowser1.Document.GetElementsByTagName("button");
    
    foreach (HtmlElement button in buttons)
    {
        if (button.InnerText == "Log me in")
        {
            button.InvokeMember("click");
        }
    }
