    public static readonly DependencyProperty IsInputProperty =
        DependencyProperty.Register("IsInput", typeof(bool), typeof(MyControl),
            new FrameworkPropertyMetadata(IsInputPropertyChanged));
    /// <summary>
    /// CLR wrapper for the 'IsInput' dependency property.
    /// </summary>
    public bool IsInput
    {
        get { return (bool)GetValue(IsInputProperty); }
        set { SetValue(IsInputProperty, value); }
    }
    /// <summary>
    /// Callback called when 'IsInput' property has changed.
    /// </summary>
    private static void IsInputPropertyChanged(
        DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        bool b = (bool)e.NewValue;
        //TODO
    }
