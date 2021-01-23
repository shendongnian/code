    var currentDate = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
    GraphClient client= new GraphClient(new Uri("http://localhost:7474/"));
    client.Connect();  
    var date=client.Cypher
                   .Match("(e2:Event)")
                   .Where((Event e2) => e2.notificationTime < currentDate)
                   .Return(e=>e.As<Event>()).Results;
