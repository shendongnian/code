    var properties = XDocument.Load("XMLFile2.xml").Descendants("property").Select(p =>
    {
        string name = p.Attribute("name").Value;
        string type = p.Attribute("type").Value;
        string value = p.Value;
    
        PropertyBag bag = new PropertyBag();
        bag.PropertyName = name;
    
        switch (type)
        {
            case "decimal":
                bag.PropertyValue = Decimal.Parse(value);
                break;
    
            case "datetime":
                bag.PropertyValue = DateTime.Parse(value);
                break;
    
            default:
                bag.PropertyValue = value;
                break;
        }
    
        return bag;
    });
