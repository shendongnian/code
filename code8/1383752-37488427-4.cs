    public static readonly DependencyProperty NavigationStyleProperty =
        DependencyProperty.Register(
            "NavigationStyle",
            typeof(NavigationStyle),
            typeof(ActionBar),
            new FrameworkPropertyMetadata(
                NavigationStyle.TwoColumnsNavigation, ValueChanged));
