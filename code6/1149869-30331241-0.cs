    var doc = XDocument.Parse(xml, LoadOptions.PreserveWhitespace);
    
    var i = 0;
    
    foreach (var node in doc.Root.Nodes())
    {
        var element = node as XElement;
        var text = node as XText;
    
        var isThing = element != null && element.Name == "thing";
        var isWhitespace = text != null && string.IsNullOrWhiteSpace(text.Value);
    
        if (isThing)
        {
            element.Add(new XAttribute("number", ++i));
        }
        else if (!isWhitespace)
        {
            i = 0;
        }
    }
    
    var result = doc.ToString();
