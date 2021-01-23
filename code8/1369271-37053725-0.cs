    XDocument doc = XDocument.Parse("<Settings><Type>15</Type><Module>True</Module><Capacity>10</Capacity></Settings>");
    var settings = doc
                   .Elements("Settings")
                   .Select(x => new Settings
                   {
                       Type = (int)x.Element("Type"),
                       Module = (bool)x.Element("Module"),
                       Capacity = (int)x.Element("Capacity"),
                    })
                    .ToList();
