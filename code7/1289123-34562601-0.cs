    var pin = new Pin();
    pin.Label = "Pin A";
    pin.Address = "blah";
    pin.Position = new Position(x1,y1);
    pin.Clicked += Pin_Clicked;
    
    map.Pins.Add(pin);
    
    pin = new Pin();
    pin.Label = "Pin B";
    pin.Address = "blah";
    pin.Position = new Position(x2,y2);
    pin.Clicked += Pin_Clicked;
    
    map.Pins.Add(pin);
    
    pin = new Pin();
    pin.Label = "Pin C";
    pin.Address = "blah";
    pin.Position = new Position(x3,y3);
    pin.Clicked += Pin_Clicked;
    
    map.Pins.Add(pin);
    
    void Pin_Clicked (object sender, EventArgs e)
    {
    	Pin pin = (Pin)sender;
    
        // now pin is the Pin that was clicked, look at it's properties
        // to determine which pin and act accordingly
    }
