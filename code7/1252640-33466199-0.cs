    Func<IEnumerable<XElement>, IEnumerable<Tenant>> getTenants = elements => {
		return elements.Select (e => new Tenant {
			Name = e.Element("Name").Value,
			Rent = decimal.Parse(e.Element("Rent").Value),
			SF = int.Parse(e.Element("SquareFeet").Value)
		});
	};
	
	Func<IEnumerable<XElement>, IEnumerable<Building>> getBuildings = elements => {
		return elements.Select (e => new Building{
		    Name = e.Element("Name").Value,
		    Tenants = getTenants(e.Elements("Tenant")).ToList()
		});
	};
	//xdoc is your parsed XML document
    //e.g. var xdoc = XDdocument.Parse("xml contents here");
	var property = new Property{
		Name = xdoc.Root.Element("Name").Value,
		Buildings = getBuildings(xdoc.Root.Elements("Building")).ToList()
	};
