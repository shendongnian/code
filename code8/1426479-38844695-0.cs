    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;
    using Microsoft.Owin.Cors;
    using Microsoft.Owin.Hosting;
    using Owin;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Http;
    
    namespace Join8POS.SignalRServer
    {
        class Program
        {
            static void Main(string[] args)
            {
                // This will *ONLY* bind to localhost, if you want to bind to all addresses
                // use http://*:8080 to bind to all addresses. 
                // See http://msdn.microsoft.com/en-us/library/system.net.httplistener.aspx 
                // for more information.
                string localComputerName = Dns.GetHostName();
                Console.WriteLine("Enter SignalR Server Host IP Address: ");
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress hostIP in localIPs)
                {
                    // is localhost
                    if (IPAddress.IsLoopback(hostIP))
                    {
    
                    }
                    if (hostIP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
    
                    }
                    var ipp= hostIP.MapToIPv4();
                }
                var inp= Console.ReadLine();
                string url = "http://"+inp+":8080";
                using (WebApp.Start(url))
                {
                    Console.WriteLine("Server running on {0}", url);
                    outer:
                    Console.WriteLine("\nPress 'C' to close SignalR server.");
                    var ky= Console.ReadKey();
                    if (ky.KeyChar != 'C')
                    {
                        goto outer;
                    }
                }
            }
        }
        class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                HttpConfiguration config = new HttpConfiguration();
                // UnityConfig.RegisterComponents(config);
                //WebApiConfig.Register(config);
                var hubConfiguration = new HubConfiguration
                {
                    // You can enable JSONP by uncommenting line below.
                    // JSONP requests are insecure but some older browsers (and some
                    // versions of IE) require JSONP to work cross domain
                    EnableJSONP = true,
                    EnableJavaScriptProxies = true,
                    EnableDetailedErrors = true
                };
                app.UseCors(CorsOptions.AllowAll);
                app.MapSignalR();
                app.Map("/signalr", map =>
                {
                    // Setup the cors middleware to run before SignalR.
                    // By default this will allow all origins. You can 
                    // configure the set of origins and/or http verbs by
                    // providing a cors options with a different policy.
                    map.UseCors(CorsOptions.AllowAll);
                    hubConfiguration.EnableDetailedErrors = true;
                    // Run the SignalR pipeline. We're not using MapSignalR
                    // since this branch is already runs under the "/signalr"
                    // path.
                    map.RunSignalR(hubConfiguration);
                });
            }
        }
        [HubName("shopApiHub")]
        public class ShopApiHub : Hub
        {
            /// <summary>
            /// ShopApiHub OnConnected
            /// </summary>
            /// <returns></returns>
            public override Task OnConnected()
            {
                //CustomLogging.Log("OnConnected  "+ Context.ConnectionId, LoggingType.SignalRShopHub);
                return base.OnConnected();
            }
            /// <summary>
            /// Invoked on Take Out order generated.
            /// </summary>
            public void TakeOutOrderRaise()
            {
                Clients.All.takeOutOrderRaise();
                //CustomLogging.Log("TakeOutOrderRaise ", LoggingType.SignalRShopHub);
            }
            /// <summary>
            /// invoked when got any update in runningtable.xml
            /// </summary>
            public void refreshFloorPlan()
            {
                Clients.All.refreshFloorPlan();
            }
            /// <summary>
            /// OnDisconnected
            /// </summary>
            /// <param name="bl"></param>
            /// <returns></returns>
            public override Task OnDisconnected(bool bl)
            {
                return base.OnDisconnected(bl);
            }
        }
    }
