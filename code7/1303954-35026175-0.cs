    var getItems = await parseAPI.getInfo (Application.Current.Properties ["sessionToken"].ToString ()); //I load my data.
    
    foreach (var currentItem in getItems["results"]) 
    {
    	mLong = currentItem ["long"].ToString (); //my long from my data
    	mLat = currentItem ["lat"].ToString (); //my lat from my data
    
    	var storeLong = Double.Parse (mLong, CultureInfo.InvariantCulture); //converting the long from string to int.
    	var storeLat = Double.Parse (mLat, CultureInfo.InvariantCulture); //converting the lat from string to int.
    
    	if (mLong != null) 
    	{
    		var ourPosition = new Position (13, -15);
    		theMap.MapType = MapType.Hybrid;
    		theMap.MoveToRegion (
    			MapSpan.FromCenterAndRadius (
    				ourPosition, Distance.FromMeters (300)));
    
    		var pin = new Pin ();
    		pin.Position = new Position (storeLat,storeLng); //here i add the data i have.
    		pin.Label = "test";
    		pin.Address = "test";
    		pin.Clicked += onButtonClicked1;
    
    		theMap.Pins.Add (pin); //adding my pins to my map. 
    	}
    }
