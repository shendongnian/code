    public static readonly DependencyProperty PropertyPinGeoposition = 
    DependencyProperty.Register("PinGeoposition", typeof(BasicGeoposition), typeof(CustomMapControl), new PropertyMetadata(null, SetPosition));
    public BasicGeoposition PinGeoposition 
    { 
        get { return (BasicGeoposition) GetValue(PropertyPinGeoposition); } 
        set { SetValue(PropertyPinGeoposition, value);}
    }
    private static void SetPosition(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        var control = (CustomMapControl)sender;
        var position = e.NewValue as BasicGeoposition;
        // Do whatever
    }
