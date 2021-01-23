    public int HighestPrice(string xmlFilePath)
    {
        var doc = XDocument.Load(xmlFilePath);
        var cars = doc.Root.Elements("Location").Select(e => e.Element("Type"));
        return cars.Max(c => int.Parse(c.Element("Price").Value));
    }
