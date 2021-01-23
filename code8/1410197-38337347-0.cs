    string documentPath;
    string undesiredPattern = "AAABBBCCC";
    XDocument xdoc = XDocument.Load(documentPath);
    XElement root = xdoc.Root;
    
    IEnumerable<XElement> desiredElements = 
     root.
     Elements().
     Where(x=>!x.Element("body").Element("cf").Value.Equals(undesiredPattern));
    
    XDocument newDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
    XElement newRoot = new XElement("documents");
    foreach(XElement xe in desiredElements)
    {
      newRoot.Add(xe);
    }
    newDoc.Add(newRoot);
    newDoc.Save(documentPath);
