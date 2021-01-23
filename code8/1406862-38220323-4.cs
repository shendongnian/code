    var targetElementNames = new[]{ "A", "B", "C" };
    XDocument.Root
             .Descendants("Car")
             .Where(c => (string)c.Element("Color") == "Green")
             .SelectMany(c => c.Elements()
    		 				   .Where(e => targetElementNames.Contains(e.Name.LocalName))
             .Remove();
