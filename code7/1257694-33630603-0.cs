    private static readonly DependencyProperty IsHighlightedProperty = DependencyProperty.Register
    (
        "IsHighlighted",
        typeof(bool),
        typeof(MyButton)
    );
    public bool IsHighlighted
    {
        get { return (bool) GetValue(IsHighlightedProperty); }
        set { SetValue(IsHighlightedProperty, value); }
    }
