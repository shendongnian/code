    using System;
    using Microsoft.AspNet.SignalR.Client;
    namespace SignalRClient
    {
        class Program
        {
            private static IHubProxy HubProxy { get; set; }
            const string ServerURI = "http://localhost:1234/signalr";
            private static HubConnection Connection { get; set; }
            static void Main(string[] args)
            {
                Connection = new HubConnection(ServerURI);
                HubProxy = Connection.CreateHubProxy("MyHub");
                HubProxy.On<string, string>("SendMessage", (name, message) => Console.WriteLine(name + ":" + message));
                Connection.Start().Wait();
                Console.WriteLine("Press Enter to stop client");
                Console.ReadLine();
            }
        }
    }
