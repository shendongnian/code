    public static readonly DependencyProperty PropertyPinGeoposition = 
    DependencyProperty.Register("PinGeoposition", typeof(BasicGeoposition), typeof(CustomMapControl), new PropertyMetadata(null, SetValue));
    private static void SetValue(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        var control = (CustomMapControl)sender;
        var position = (BasicGeoposition)e.NewValue;
        // Do whatever
    }
