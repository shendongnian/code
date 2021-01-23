    public static void DisruptionDisplayNamePropertyCallback(DependencyObject dp, DependencyPropertyChangedEventArgs args)
    {
        var iconDisplayName = (string)e.NewValue;
        ((DisruptionIcon)dp).DisplayName = iconDisplayName;
    }
