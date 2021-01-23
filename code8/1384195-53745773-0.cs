       static void Main(string[] args)
       {
          var client = new WebSocketClient<WebSocketMessagingService>("ws://localhost:8080");
          client.Open();
     
          Console.WriteLine(client.Request<string>("Hello", "Hello there !!!"));
          Console.WriteLine(client.Request<string>("GoodBye"));
          Console.Read();
       }
