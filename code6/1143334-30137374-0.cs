    var document = XDocument.Load(filename, LoadOptions.SetLineInfo);
    
    var excludedAttributes = new HashSet<XName>
    {
        "{http://schemas.microsoft.com/winfx/2006/xaml}Class",
        "Width",
        "Height",
        "Margin",
        "HorizontalAlignment"
    };
    
    foreach (var element in document.Descendants())
    {
        IXmlLineInfo lineInfo = element;
    
        var sb = new StringBuilder();
    
        sb.AppendFormat("({0}) ", lineInfo.LineNumber);
        sb.Append(element.Name.LocalName);
    
        var outputAttributes = element.Attributes()
            .Where(a => !a.IsNamespaceDeclaration && !excludedAttributes.Contains(a.Name));
    
        foreach (var attribute in outputAttributes)
        {
            sb.AppendFormat(" {0}=\"{1}\"", attribute.Name, attribute.Value);
        }
    
        if (element.Nodes().OfType<XText>().Any())                
        {
            sb.Append(" ");
            sb.Append(element.Value.Replace("\n", string.Empty).Trim());
        }
    
        WriteLine(sb.ToString());
    }
