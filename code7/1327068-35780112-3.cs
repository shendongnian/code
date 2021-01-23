    var fordTrucks = someXml.Root.Elements.Where(elem => elem.Attributes("Type").Value == "Ford").Select(elem => {
        return new Truck() {
            Type = Enum.Parse(TypeOf(TruckTypes), elem.Attribute("Type").Value),
            Model = elem.Attribute("Model").Value
        }
    });
