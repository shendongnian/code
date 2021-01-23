    HtmlElement element;
    //username fill
    element = webBrowser.Document.GetElementById("name");
    if (element != null)
    {
        element.InnerText = "username";
    }
    //pass fill
    HtmlElementCollection elements = null;
    elements = webBrowser.Document.All.GetElementsByName("pass");
    element = elements[0];
    element.InnerText = "password";
    //login (click)
    elements = webBrowser.Document.All.GetElementsByName("submit");
    element  = elements[0];
    element.InvokeMember("CLICK");
