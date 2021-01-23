    using System;
    private async void WifiConnectionLost()
    {
        ContentDialog noWifiDialog = new ContentDialog()
        {
            Title = "No wifi connection",
            Content = "Check connection and try again",
            PrimaryButtonText = "Ok"
        };
        await noWifiDialog.ShowAsync();
    }
