    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Client;
    using Microsoft.Owin.Hosting;
    using Owin;
    namespace SignalRServer
    {
        class Program
        {
            static private IDisposable SignalR { get; set; }
            const string ServerURI = "http://localhost:1234";
            private static IHubProxy HubProxy { get; set; }
            private static HubConnection Connection { get; set; }
            static void Main(string[] args)
            {
                SignalR = WebApp.Start(ServerURI);
                Console.WriteLine("Server running at " + ServerURI);
                Connection = new HubConnection(ServerURI);
                HubProxy = Connection.CreateHubProxy("MyHub");
                HubProxy.On<string, string>("SendMessage", (name, message) => Console.WriteLine(name + ":" + message));
                Connection.Start().Wait();
                string messageToSentToClients;
                do
                {
                    Console.WriteLine("Type someting to send to clients and press enter");
                    messageToSentToClients = Console.ReadLine();
                   HubProxy.Invoke("Send", "Server", messageToSentToClients);
               } while (messageToSentToClients != "exit");
           }
        }
        public class MyHub : Hub
        {
            public void Send(string name, string message) { Clients.All.sendMessage(name, message); }
        }
        class Startup
        {
            public void Configuration(IAppBuilder app) { app.MapSignalR(); }
        }
    }
