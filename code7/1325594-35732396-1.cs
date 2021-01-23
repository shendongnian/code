    foreach (HtmlElement el in webBrowser.Document.GetElementsByTagName("li"))
    {
    if (el.InnerText.Contains("Vans, Trucks & Plant"))
      el.InvokeMember("click");
    }
