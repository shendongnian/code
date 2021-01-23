    HubProxy.On("ApplyChangedSettings", () =>   ApplyChangedSettings().ConfigureAwait(false));
    public async Task ApplyChangedSettings()
     {
       if (ConnectionTimeEntryHub.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Connected)
            {
                await ApplySettings().ConfigureAwait(false);
            }
     }
