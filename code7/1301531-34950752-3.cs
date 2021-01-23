    public static readonly DependencyProperty IsInputProperty =
        DependencyProperty.Register("IsInput", typeof(bool), typeof(FrameworkElement),
            new FrameworkPropertyMetadata(IsInput_PropertyChanged));
    /// <summary>
    /// Event raised when 'IsInput' property has changed.
    /// </summary>
    private static void IsInput_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        bool b = (bool)e.NewValue;
        //TODO
    }
