            var doc = XDocument.Parse(xml); // Load the XML
            string prefix = "L"; // Or whatever.
            // Use doc.Root.Descendants() instead of doc.Descendants() to avoid accidentally removing the root element.
            var elements = doc.Root.Descendants().Where(e => e.Name.LocalName.StartsWith(prefix, StringComparison.Ordinal));
            elements.Remove();
