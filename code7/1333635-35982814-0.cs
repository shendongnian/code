    HtmlElementCollection elCol = webBrowser1.Document.GetElementsByTagName("option");
    foreach (HtmlElement el in elCol)
    {
         if(el.InnerText == "32")
         {
              String val = el.GetAttribute("value");
    		  webBrowser1.Document.GetElementById("size").SetAttribute("value", val);
              break;
         }
    }
