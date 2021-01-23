    HtmlDocument doc = webBrowser1.Document;
    HtmlElement userName = doc.GetElementById("User");
    HtmlElement pass = doc.GetElementById("Password");
    userName.SetAttribute("value", "user123");
    pass.SetAttribute("value", "pass321");
     HtmlElementCollection elc = this.webBrowser1.Document.GetElementsByTagName("input");
    foreach (HtmlElement el in elc)
    {
      if (el.GetAttribute("type").Equals("submit"))
      {
          el.InvokeMember("Click");
       }
    }
