    public static readonly DependencyProperty TextHeaderProperty = DependencyProperty.Register("TextHeader", typeof(string), typeof(StyledPanel))
    public string TextHeader
    {
        get { return (string)GetValue(TextHeaderProperty); }
        set { SetValue(TextHeaderProperty, value); }
    }
