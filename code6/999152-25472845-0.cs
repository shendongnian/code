    public BitmapImage ColorWheelImage
    {
        get { return (BitmapImage)GetValue(ColorWheelImageProperty); }
        set { SetValue(ColorWheelImageProperty, value); }
    }
    
    public static readonly DependencyProperty ColorWheelImageProperty =
        DependencyProperty.Register("ColorWheelImage", typeof(BitmapImage), 
                                     typeof(ColorPicker));
