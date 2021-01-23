    var pin = new CustomPin ();
        pin.MapPin.Label = "Test";
        pin.MapPin.Position = new Position(32, 10);
        pin.MapPin.Label = "1";
        pin.MapPin.Address = "394 Pacific Ave, San Francisco CA";
        pin.Id = "Xamarin";
    
       var pin1 = new CustomPin ();
        pin1.MapPin.Label = "Test2";
        pin1.MapPin.Position = new Position(33, 10);
        pin1.MapPin.Label = "2";
        pin1.MapPin.Address = "394 Pacific Ave, San Francisco CA";
        pin1.Id = "Xamarin";
    
        mymap.CustomPins = new List<CustomPin> { pin,pin1 };
        mymap.Pins.Add (pin.MapPin);
        mymap.Pins.Add (pin1.MapPin);
