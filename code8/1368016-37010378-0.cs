    IEnumerable<Client> clients = 
        from client in XDocument.Load(@"D:\W\Clients.xml").Descendants("client")
        orderby client.Element("Id") descending
        select new Client()
        {
            ClientName = client.Element("name").Value,
            Adresses = client.[Insert code to select addresses here]
                .Select(address => new List<Adress>()
                {
                    new Adress()
                    {
                        AdressName = address.[insert code to get address name here]
                        Ip = address.[insert code to get ip here]
                        port = address.[insert code to get port here]
                    }
                }
                .ToList()
        };
