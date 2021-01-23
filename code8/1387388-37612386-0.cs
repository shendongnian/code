    Label NameLbl = new Label()
    {
         TextColor = Color.Black,
         HorizontalTextAlignment = TextAlignment.Center,
         FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
    };
    
    NameLbl.SetBinding(Label.TextProperty, "StopName");
    NameLbl.SetBinding(Label.IsVisibleProperty, "ShowStopName");
