      for (var i = 0; i < numberOfClients; i++) {
        using{var controlClient = new ReactiveClient("127.0.0.1", 1055)) 
        {
           controlClient.ConnectAsync().Wait();
           Console.WriteLine(@"Connect");
           Task.Delay(200).Wait();
           controlClient.Disconnect();
           Console.WriteLine(@"Disconnect");
        }
      }
    }
