            var pin = new Grid();                        
            pin.Tapped += Pin_Tapped; //Binding tap event for current pin.
            pin.Children.Add(new Ellipse()
            {
                Fill = new SolidColorBrush(Colors.DodgerBlue),
                Stroke = new SolidColorBrush(Colors.White),
                StrokeThickness = 1,
                Width = 20,
                Height = 20,
            });
           
            MapControl.SetLocation(pin, <GeoPoint_Where_You_Need_The_Pin>);
            mapControlName.Children.Add(pin);
