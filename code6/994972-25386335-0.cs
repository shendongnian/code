       var clients = new List<System.Net.Http.HttpClient>();
            for (int i = 0; i < 10; i++)
            {
                var client = new System.Net.Http.HttpClient();
                var response = client.GetAsync("http://www.google.com").Result;
                clients.Add(client);
            }
            foreach (var client in clients)
                client.Dispose();
