    string name = string.Format("attachment; filename={0:yyyyMMddHHmmss}.xml", DateTime.Now);
    HttpContext.Current.Response.ContentType = "application/xml";
    HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
    HttpContext.Current.Response.AppendHeader("Content-Disposition", name);
    
    DataTable dataTable = dsData.Tables[0];             
    
    XmlWriterSettings xws = new XmlWriterSettings { OmitXmlDeclaration = true };
    
    using (XmlWriter xmlWriter = XmlWriter.Create(
             HttpContext.Current.Response.OutputStream,  // The OutputStream of the HttpResponse
             xws))
    {
      xmlWriter.WriteStartElement("root");
    
      foreach (DataRow dataRow in dataTable.Rows)
      {
        xmlWriter.WriteStartElement("datanode");
        foreach (DataColumn dataColumn in dataTable.Columns)
        {
             xmlWriter.WriteElementString(
                 dataColumn.ColumnName.Replace("\n\r", " ")
                                      .Replace("\n", " ")
                                      .Replace("\r", " "), 
                 Convert.ToString(dataRow[dataColumn]).Replace("\n\r", " ")
                                                      .Replace("\n", " ")
                                                      .Replace("\r", " "));
                            }
             xmlWriter.WriteEndElement();
         }
         xmlWriter.WriteEndElement();
         xmlWriter.Flush();
         xmlWriter.Close();
       }
    
    HttpContext.Current.Response.End();
