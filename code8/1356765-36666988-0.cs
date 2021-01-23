    public static DependencyProperty MainMenuFlyoutProperty =
        DependencyProperty.Register(
            "MainMenuFlyout", typeof(MainMenuFlyout), typeof(MainMenuButton),
            new PropertyMetadata(null, MainMenuFlyoutPropertyChangedCallback));
    public MainMenuFlyout MainMenuFlyout
    {
        get { return (MainMenuFlyout)GetValue(MainMenuFlyoutProperty); }
        set { SetValue(MainMenuFlyoutProperty, value); }
    }
