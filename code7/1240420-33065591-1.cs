    HtmlElement element;
    // Filling the username
    element = webBrowser.Document.GetElementById("ContentPlaceHolder1_UsernameTextBox");
    if (element != null)
    {
        element.InnerText = "username";
    }
    // In case if there is no id of the input field you can get it by name
    HtmlElementCollection elements = null;
    elements = webBrowser.Document.All.GetElementsByName("pass");
    element = elements[0];
    element.InnerText = "password";
    //login (click)
    elements = webBrowser.Document.All.GetElementsByName("submit");
    element  = elements[0];
    element.InvokeMember("CLICK");
