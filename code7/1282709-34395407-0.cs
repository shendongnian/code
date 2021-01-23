    public static readonly DependencyProperty Second_bindedProperty =
            DependencyProperty.Register(
            "Second_binded",
            typeof(string),
            typeof(ClockControl),
            new PropertyMetadata("", PropertyChangedCallback));
    private static void PropertyChangedCallback(DependencyObject dependencyObject,
                 DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
    {
        Debug.WriteLine(" in Second_binded callback");
    }
