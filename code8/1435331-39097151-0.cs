    Try
    
    protected string ConvertXmlToHtmlTable(string xml)
    {
      StringBuilder html = new StringBuilder("<table align='center' " + 
         "border='1' class='xmlTable'>\r\n");
      try
      {
          XDocument xDocument = XDocument.Parse(xml);
          XElement root = xDocument.Root;
    
          var xmlAttributeCollection = root.Elements().Attributes();
    
    
          foreach (var ele in root.Elements())
          {
              if (!ele.HasElements)
              {
                  string elename = "";
                  html.Append("<tr>");
    
                  elename = ele.Name.ToString();
    
                  if (ele.HasAttributes)
                  {
                      IEnumerable<XAttribute> attribs = ele.Attributes();
                      foreach (XAttribute attrib in attribs)
                      elename += Environment.NewLine + attrib.Name.ToString() + 
                        "=" + attrib.Value.ToString();
                  }
    
                  html.Append("<td>" + elename + "</td>");
                  html.Append("<td>" + ele.Value + "</td>");
                  html.Append("</tr>");
              }
              else
              {
                  string elename = "";
                  html.Append("<tr>");
    
                  elename = ele.Name.ToString();
    
                  if (ele.HasAttributes)
                  {
                      IEnumerable<XAttribute> attribs = ele.Attributes();
                      foreach (XAttribute attrib in attribs)
                      elename += Environment.NewLine + attrib.Name.ToString() + "=" + attrib.Value.ToString();
                  }
    
                  html.Append("<td>" + elename + "</td>");
                  html.Append("<td>" + ConvertXmlToHtmlTable(ele.ToString()) + "</td>");
                  html.Append("</tr>");
              }
          }
    
          html.Append("</table>");
      }
      catch (Exception e)
      {
          return xml;
          // Returning the original string incase of error.
      }
      return html.ToString();
    }
