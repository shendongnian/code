    private async void SetupUserInterface()
    {
       var activity = this.Context as Activity;
       Device.BeginInvokeOnMainThread(async() =>
       {
           view = activity.LayoutInflater.Inflate(Resource.Layout.mapLayout, this, false);
           // instanciando el mapa
           map = FindViewById<MapView>(Resource.Id.mapView);
           map.StyleUrl = Mapbox.Constants.Style.Emerald;
           var mapboxMap = await map.GetMapAsync();
           var position = new CameraPosition.Builder()
           .Target(new LatLng(41.885, -87.679))
           .Zoom(11)
           .Build();
           mapboxMap.AnimateCamera(CameraUpdateFactory.NewCameraPosition(position), 2500);
       });
    }
