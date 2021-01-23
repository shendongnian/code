    var eventHubClient = EventHubClient.CreateFromConnectionString("connectionString", "eventHubName");
    var mypoco = new POCO();
    // ...
    // Get the Json string
    var stringBody = JsonConvert.SerializeObject(mypoco);
    // Create the event data
    var eventData = new EventData(Encoding.UTF8.GetBytes(stringBody));
    // Add the event type.
    eventData.Properties.Add("EventType", typeof(POCO).Assembly.FullName);
    // Send the data.
    eventHubClient.Send(eventData);
