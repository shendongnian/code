    public string Label
    {
        get { return (string)GetValue(LabelProperty); }
        set { SetValue(LabelProperty, value); }
    }
    // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty LabelProperty =
        DependencyProperty.Register("Label", typeof(string), typeof(MyClassName), new PropertyMetadata(string.Empty));
