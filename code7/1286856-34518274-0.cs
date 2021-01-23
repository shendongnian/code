    XDocument doc;
    XNamespace ns = 
        XNamespace.Get(@"http://schemas.openxmlformats.org/wordprocessingml/2006/main");
    using (WordprocessingDocument doc = WordprocessingDocument.Open(stream, true))
    {
      using (StreamReader sr = new StreamReader(doc.MainDocumentPart.GetStream()))
      using (XmlReader xr = XmlReader.Create(sr))
         xdoc = XDocument.Load(xr);
       
      XElement table;
      //Descendants() gets all children,grandchildren etc.
      //First get document -> body ->
      XElement tablecapt = xdoc.Elements().First().Elements().First()
                               .Descendants().Where(d => d.Name == XName.Get("tblCaption", ns) 
                                                    && d.Value == "TBL_TEST").FirstOrDefault();
       if (tablecapt != null)
         table = tablecapt.Parent.Parent;
    }
