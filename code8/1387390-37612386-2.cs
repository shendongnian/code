    Label NameLbl = new Label()
    {
        TextColor = Color.Black,
        HorizontalTextAlignment = TextAlignment.Center,
        VerticalOptions = LayoutOptions.Start,
        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
    };
    NameLbl.SetBinding(Label.TextProperty, "StopName");
    NameLbl.SetBinding(Label.IsVisibleProperty, "StopName",BindingMode.Default,new StringToBoolConverter(), null);
