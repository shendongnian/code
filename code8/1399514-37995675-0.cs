    private object _addressCallbackToken;
    private async void ResolveAddress()
    {
      Debug.WriteLine("Resolving adress ...");
      var token = _addressCallbackToken = new object();
      var result = await MapLocationFinder.FindLocationsAtAsync(SelectedLocation);
      if (token != _addressCallbackToken)
        return;
      if (result.Status == MapLocationFinderStatus.Success)
      {
        if (result.Locations.Count > 0)
        {
          Debug.WriteLine("Adress resolved : " + Address);
          Address = result.Locations[0].Address.FormattedAddress;
        }
      }
      Debug.WriteLine("Resolve fail");
    }
