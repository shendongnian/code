        var hubConnection = new HubConnection("http://localhost:53748");
        var chat = hubConnection.CreateHubProxy("ChatHub");
        
        chat.On<string, string>("broadcastMessage", (name, message) => { Console.Write(name + ": "); Console.WriteLine(message); });
        
        hubConnection.Start().Wait();
        chat.Invoke("Notify", "Console app", hubConnection.ConnectionId);
