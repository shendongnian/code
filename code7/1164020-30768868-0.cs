            var doc = XDocument.Parse(xml); // Load the XML
            string prefix = "L"; // Or whatever.
            var elements = doc.Descendants().Where(e => e.Name.LocalName.StartsWith(prefix, StringComparison.Ordinal)).ToList();
            foreach (var element in elements.Where(e => e.Parent != null))
                elements.Remove();
