    XElement xRoot = XElement.Parse(xmlText);
    XElement xItinerary = xRoot.Elements().First();
    // or xItinerary = xRoot.Element("itinerary");
    foreach (XElement node in xItinerary.Elements())
    {
        // Read node here: node.Name, node.Value and node.Attributes()
    }
