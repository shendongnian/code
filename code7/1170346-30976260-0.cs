    using System;
    using Microsoft.AspNet.SignalR;
    using Microsoft.Owin.Cors;
    using Microsoft.Owin.Hosting;
    using Owin;
    
    namespace SignalRWindowsService
    {
        static class Program
        {
            static void Main()
            {
                string url = "http://localhost:8080";
                WebApp.Start(url);
    
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();            
            }
        }
    
        class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                //This means you can access the web sockets from the local service (on a different URL) than the domain the page in the browser was served up from.
                app.UseCors(CorsOptions.AllowAll);
                app.MapSignalR();
            }
        }
    
        public class MyHub : Hub
        {
            public void Send(string name, string message)
            {
                Clients.All.addMessage(name, message);
            }
        }
    }
