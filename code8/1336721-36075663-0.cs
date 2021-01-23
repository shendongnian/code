    public StartPage ()
    {
        searchBar.TextChanged += (sender2, e2) => FilterPins(searchBar.Text);
    
        searchBar.SearchButtonPressed += (sender2, e2) => FilterPins(searchBar.Text);
    }
    // create a list to store our Pins 
    List<Pin> myPins = new List<Pin>();
    
    private async override void OnAppearing() {
    
      if (myPins.Count == 0) {
        myPins = await LoadData();
    
        filterPins(string.Empty);
      }
    }
    
    // load the data, geocode, store results
    private async List<Pin> LoadData() {
    
      var pins = new List<Pin>();
    
      var getItems = await phpApi.getInfo ();
    
      foreach (var currentItem in getItems["results"]) {
    
        Geocoder gc = new Geocoder ();
        var pos = await gc.GetPositionsForAddressAsync (theUserPosition);
    
        foreach (Position p in pos) {
      
          var pin = new Pin ();
          pin.Position = new Position (p.Latitude, p.Longitude);
          pin.Label = theName;
          pin.Address = theAdress;                    
     
          pins.Add(pin);
        }     
      }
    
      return pins;
    }
    
    private  async void FilterPins (string filter)
    {
      map.Pins.Clear ();
      
      foreach(Pin p in myPins) {
        if (string.IsNullOrWhiteSpace(filter) || (p.Address.Contains(filter)) {
          map.Pins.Add(p);
        }
      }
    }
