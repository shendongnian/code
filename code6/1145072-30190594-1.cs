    private static void RemoveNamespaces(XElement element)
    {
        // remove namespace prefix
        element.Name = element.Name.LocalName;
    
        // remove namespaces from children elements
        foreach (var elem in element.Elements())
        {
            RemoveNamespaces(elem);
        }
    
        // remove namespace attributes
        foreach (var attr in element.Attributes())
        {
            if (attr.IsNamespaceDeclaration)
            {
                attr.Remove();
            }
        }
    }
