    public string TabText
    {
        get { return (string)GetValue(TabTextProperty); }
        set { SetValue(TabTextProperty, value); }
    }
    public static readonly DependencyProperty TabTextProperty = DependencyProperty.Register("TabText", typeof(string), typeof(Tab1), new PropertyMetadata("Default"));
