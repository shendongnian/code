    HtmlElementCollection head = webBrowser1.Document.GetElementsByTagName("head");
    if (head != null)
    {
    HtmlElement _elment = webBrowser1.Document.CreateElement("script");
    _elment.SetAttribute("type", "text/javascript");
    _elment.InnerText = System.IO.File.ReadAllText(Environment.CurrentDirectory + @"virtual Js path"); 
    //OR  _elment.InnerText = js text";
    ((HtmlElement)head[0]).AppendChild(_elment);
    }
