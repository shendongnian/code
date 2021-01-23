    var doc = XDocument.Parse(xml);
    
    doc.Descendants().Attributes().Where(a => a.IsNamespaceDeclaration).Remove();
    
    foreach (var element in doc.Descendants())
    {
        element.Name = element.Name.LocalName;
    }
    var xmlWithoutNamespaces = doc.ToString();
