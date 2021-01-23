    var xmlns = XNamespace.Xmlns;
    XNamespace oldNs = "http://www.w3.org/1999/xlink";
    XNamespace newNs = "http://www.w3.org/1998/Math/MathML";
    // change the declarations
    var decls =
        from a in doc.Descendants().Attributes()
        where a.Name == xmlns + "xlink"
        select a;
    foreach (var decl in decls)
        decl.Value = newNs.NamespaceName;
    // change the names of existing elements
    var nodes =
        from n in doc.Descendants()
        where n.Name.Namespace == oldNs
        select n;
    foreach (var node in nodes)
        node.Name = newNs + node.Name.LocalName;
    // don't forget the attributes as well
    var attrs =
        from a in doc.Descendants().Attributes()
        where a.Name.Namespace == oldNs
        select a;
    foreach (var attr in attrs)
    {
        // can't change the names directly, the attributes must be replaced
        var newName = newNs + attr.Name.LocalName;
        attr.Parent.Add(new XAttribute(newName, attr.Value));
        attr.Remove();
    }
