    XNamespace z = "http://schemas.microsoft.com/2003/10/Serialization/";
    XNamespace ns = "http://schemas.datacontract.org/ConfigurationInterfaces";
    var list = XDocument.Load(filename)
                .Descendants(ns + "Outputs")
                .First()
                .Descendants(ns + "InstrumentParameter")
                .Select(e => new
                {
                    id = (string)e.Attribute(z + "Id"),
                    ChannelNumber = (string)e.Element(ns + "ChannelNumber"),
                    InstrumentParameterType = (string)e.Element(ns + "InstrumentParameterType"),
                    IsMetaData = (string)e.Element(ns + "IsMetaData"),
                    Name = (string)e.Element(ns + "Name"),
                })
                .ToList();
