            hubConnection.Closed += () => {
                connected = false;
                while (!connected)
                {
                    System.Threading.Thread.Sleep(2000);
                    hubConnection = new HubConnection("http://localhost:8080/signalr", "source=" + feed, useDefaultUrl: false);
                    priceProxy = hubConnection.CreateHubProxy("UTHub");
                    hubConnection.Start().Wait();
                    connected = true;
                }
            };
