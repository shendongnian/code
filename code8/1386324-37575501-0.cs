    XElement root = XElement.Load(file); // or use your doc.Root instead
    var peds = root.Elements("Pedestrian")
        .Select(p => new
        {
            Name = (string)p.Attribute("Name"),
            InitialPosition = new
            {
                X = (int)p.Element("Initial_Position").Attribute("In_X"),
                Y = (int)p.Element("Initial_Position").Attribute("In_Y")
            },
            FinalPositions = p.Elements("Final_Position")
                    .Select(f => new
                    {
                        X = (int)f.Attribute("Fin_X"),
                        Y = (int)f.Attribute("Fin_Y"),
                        Time = (int)f.Attribute("Time")
                    }).ToArray()
        }).ToArray();
