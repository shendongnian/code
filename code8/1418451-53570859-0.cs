    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using System.Diagnostics;
    using Microsoft.AspNetCore.Builder;
    using static System.Runtime.InteropServices.RuntimeInformation;
    using static System.Runtime.InteropServices.OSPlatform;
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:54321/";
            using (var server = CreateServer(args, url))
            {
                StartBrowserWhenServerStarts(server, url);
                server.Run(); //blocks
            }
        }
        /// <summary>
        /// Create the kestrel server, but don't start it
        /// </summary>
        private static IWebHost CreateServer(string[] args, string url) => WebHost
            .CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .UseUrls(url)
            .Build();
        /// <summary>
        /// Register a browser to launch when the server is listening
        /// </summary>
        private static void StartBrowserWhenServerStarts(IWebHost server, string url)
        {
            var serverLifetime = server.Services.GetService(typeof(IApplicationLifetime)) as IApplicationLifetime;
            serverLifetime.ApplicationStarted.Register(() =>
            {
                var browser =
                    IsOSPlatform(Windows) ? new ProcessStartInfo("cmd", $"/c start {url}") :
                    IsOSPlatform(OSX) ? new ProcessStartInfo("open", url) :
                    new ProcessStartInfo("xdg-open", url); //linux, unix-like
                Process.Start(browser);
            });
        }
    }
