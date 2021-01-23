    var query = XElement.Load("data.xml")
                        .Descendants("Client")
                        .Select(client => new {
                                   MachineName = client.Attribute("MachineName").Value,
                                   GroupName = client.Ancestors("Group").Select(g => g.Attribute("Name").Value).First()
                               });
    foreach (var x in query)
        Console.WriteLine($"GroupName: {x.GroupName}, MachineName: {x.MachineName}");
