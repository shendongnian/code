    public static readonly DependencyProperty
        SecurityIdProperty =
        DependencyProperty.Register("SecurityId",
        typeof(string), typeof(SomeView),
        new PropertyMetadata("", new PropertyChangedCallback(MyValueChanged)));
