    public static readonly DependencyProperty StateProperty =
        DependencyProperty.Register(
             "State",
             typeof(string),
             typeof(StatusElement),
             new PropertyMetadata(null, (o, e) => ((StatusElement)o).RefreshState()));
    public string State
    {
        get { return (string)GetValue(StateProperty); }
        set { SetValue(StateProperty, value); }
    }
