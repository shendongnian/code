        private async Task ConnectToSignalR()
        {
            var hubConnection = new HubConnection("url");
            hubConnection.Headers["x-zumo-application"] = "clientapikey";
            IHubProxy proxy = hubConnection.CreateHubProxy("ChatHub");
            proxy.On<string>("hello", async (msg) =>
            {
                Console.WriteLine(msg);
            });
            
            await hubConnection.Start();
        }
