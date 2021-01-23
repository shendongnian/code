    private void MyMap_MapTapped(Windows.UI.Xaml.Controls.Maps.MapControl sender, Windows.UI.Xaml.Controls.Maps.MapInputEventArgs args)
    {
        var tappedGeoPosition = args.Location.Position;
        string status = "MapTapped at \nLatitude:" + tappedGeoPosition.Latitude + "\nLongitude: " +
    tappedGeoPosition.Longitude;
        rootPage.NotifyUser( status, NotifyType.StatusMessage);
    }
