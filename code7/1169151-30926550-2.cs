    var cityList = new List<City>();            
    XDocument xDoc = XDocument.Load(Server.MapPath("/App_Data/Countries.xml"));
    foreach (XElement xCountry in xDoc.Root.Elements())
    {
        int id = int.Parse(xCountry.Element("Id").Value);
        string name = xCountry.Element("City").Value;                
        cityList.Add(new City(id, name));
    }
