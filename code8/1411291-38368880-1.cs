    public static readonly DependencyProperty AreTextBoxesEnabledProperty = DependencyProperty.Register(
        "AreTextBoxesEnabled",
        typeof(bool),
        typeof(MyUserControl));
    public bool AreTextBoxesEnabled
    {
        get { return (bool)GetValue(AreTextBoxesEnabledProperty); }
        set { SetValue(AreTextBoxesEnabledProperty, value); }
    }
