    private static readonly DependencyProperty IsHighlightedProperty = DependencyProperty.Register
    (
        "IsHighlighted",
        typeof(bool),
        typeof(MyButton),
        new PropertyMetadata((bool)false)
    );
    public bool IsHighlighted
    {
        get { return (bool) GetValue(IsHighlightedProperty); }
        set { SetValue(IsHighlightedProperty, value); }
    }
