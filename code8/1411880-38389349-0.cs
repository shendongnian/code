    // Generate the temporary XDocument
    var ns = Namespaces.GetFSAMarketsFeedNamespace();
    var doc = data.SerializeToXDocument(null, ns);
    var root = doc.Root;
    // Add redundate xmlns= attributes
    var name = XName.Get("CoreItemsMkt", Namespaces.FSAMarketsFeed);
    var query = doc.Descendants(name); // Could be a more complex query, possibly even an XPath query.
    foreach (var element in query)
    {
        if (!element.Attributes().Any(a => a.IsNamespaceDeclaration))
        {
            var prefix = element.GetPrefixOfNamespace(element.Name.Namespace);
            if (string.IsNullOrEmpty(prefix))
                element.Add(new XAttribute("xmlns", element.Name.NamespaceName));
            else
                element.Add(new XAttribute(XNamespace.Xmlns + prefix, element.Name.NamespaceName));
        }
    }
    // Write the XDocument to disk.
