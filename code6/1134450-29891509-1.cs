    // Simulate DB call
    var clients = new List<Client>
    {
        new Client
        {
            Created = new DateTime(2015, 4, 27, 11, 48, 22, DateTimeKind.Unspecified),
            CreatedTimeZoneId = "FLE Standard Time"
        }
    };
    
    var clientDtos = clients.Select(client => new ClientDto(client));
    var json = JsonConvert.SerializeObject(clientDtos);
