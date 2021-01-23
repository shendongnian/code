                string url = "http://*:8080/";
                StartOptions options = new StartOptions();
                options.Urls.Add(url);
                SignalRServer = WebApp.Start(options, builder =>
                {
                    builder.UseCors(CorsOptions.AllowAll);
                    builder.MapSignalR("/signalr", new HubConfiguration
                    {
                        // You can enable JSONP by uncommenting line below.
                        // JSONP requests are insecure but some older browsers (and some
                        // versions of IE) require JSONP to work cross domain
                        EnableJSONP = false,
                        // Turns on sending detailed information to clients when errors occur, disable for production
                        EnableDetailedErrors = true,
                        EnableJavaScriptProxies = true
                    });
                    builder.RunSignalR();
                });
