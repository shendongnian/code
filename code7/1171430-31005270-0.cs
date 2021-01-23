    string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
        "<root xmlns:test=\"urn:my-test-urn\">" +
        "<Item name=\"Item one\">" +
        "<test:AlternativeName>Another name</test:AlternativeName>" +
        "<Price test:Currency=\"GBP\">124.00</Price>" +
        "</Item>" +
        "</root>";
    
    XDocument xDocument = XDocument.Parse(xml);
    if (xDocument.Root != null)
    {
        string namespaceValue = xDocument.Root.Attributes().Where(a => a.IsNamespaceDeclaration).FirstOrDefault().Value;
    
        // Removes elements with the namespace
        xDocument.Root.Descendants().Where(d => d.Name.Namespace == namespaceValue).Remove();
                
        // Removes attributes with the namespace
        xDocument.Root.Descendants().ToList().ForEach(d => d.Attributes().Where(a => a.Name.Namespace == namespaceValue).Remove());
    
        Console.WriteLine(xDocument.ToString());
    }
