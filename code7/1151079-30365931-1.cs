    System.IO.StringWriter stringWrite = new System.IO.StringWriter(); 
    System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite); 
    div_myDiv.RenderControl(htmlWrite); 
    string myText = stringWrite.ToString().Replace("&", "&amp;");
    XmlDocument xDoc = new XmlDocument(); 
    xDoc.LoadXml(myText); 
    string rawText = xDoc.InnerText;
