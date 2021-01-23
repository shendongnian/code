    HtmlElementCollection classButton = WebBrowser1.Document.All;
    foreach (HtmlElement element in classButton)
    {
        if (element.GetAttribute("className") == "button color")
        {
           element.InvokeMember("click");
           break; //Add the break after the InvokeMember is called to only invoke the 1st button click.
        }
    }
