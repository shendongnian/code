    private void Aberdeen()
    {
    
        if (TXTCounty.Text == "Aberdeen") {
            Microsoft.Maps.MapControl.WPF.Location[] CountyLocation = new Microsoft.Maps.MapControl.WPF.Location[3];
        
            // Error 1: Setting array variables is done using square brackets, otherwise it's considered a method invocation
            CountyLocation[0] = new Microsoft.Maps.MapControl.WPF.Location(57.143652, -2.1056584);
            CountyLocation[1] = new Microsoft.Maps.MapControl.WPF.Location(57.143652, -2.1056584);
            CountyLocation[2] = new Microsoft.Maps.MapControl.WPF.Location(57.124838, -2.0991633);
    
            // extra: you don't need dynamic here, just var will do
            var names = new string[] {
                "Aberdeen Central",
                "Aberdeen Lochnagar",
                "\tAberdeen Kincorth"
            };
    
            // Error 2: you need to declare the index variable (added var)
            for (var index = 0; index <= CountyLocation.Length - 1; index++) {
                // Error 3: don't need dynamic here
                var Pin = new Microsoft.Maps.MapControl.WPF.Pushpin();
    
                // don't need dynamic here 
                var CoordinateTip = new ToolTip();
                // Same as error 1: Array access is done with square brackets
                CoordinateTip.Content = names[index];
                // Same as error 1: Array access is done with square brackets    
                Pin.Location = CountyLocation[index];
                Pin.ToolTip = CoordinateTip;
                BingMap.Children.Add(Pin);
            }   
        }
    }
