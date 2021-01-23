    XDocument xdoc = XDocument.Load("kkk.kml");
    XNamespace ns = "http://www.opengis.net/kml/2.2";
    xdoc.Descendants(ns + "Style").Remove();
    XElement newDoc = RemoveAllNamespaces(xdoc.Root);
    xdoc.Save("kkk-mod.kml");
    public static XElement RemoveAllNamespaces(XElement e)
    {
        
        return new XElement(e.Name.LocalName,
          (from n in e.Nodes()
           select ((n is XElement) ? RemoveAllNamespaces(n as XElement) : n)),
             (e.HasAttributes) ?
               (from a in e.Attributes()
                where (!a.IsNamespaceDeclaration)
                select new XAttribute(a.Name.LocalName, a.Value)) : null);
    }
