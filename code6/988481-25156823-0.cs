    // xml is your Xml file as a string
    var doc = XDocument.Parse(xml);
    // You could also load it from a file if you wanted
    // var doc = XDocument.Load(fileLocation);
    // You can now query the XDocument with Linq
    // E.g. using fluent syntax
    var items = doc.Descendants("HandlingData").Elements("Item");
    // Or use the query expression syntax
    var query = from i in items 
                select new { 
                    HandlingName = i.Element("handlingName").Value, 
                    Mass = i.Element("fMass").Attribute("value").Value 
                };
    Console.WriteLine("{0} - {1}", query.First().HandlingName, query.First().Mass);
    // Prints: Car1 - 140000.000000
