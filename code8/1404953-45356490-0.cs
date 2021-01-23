    private void UpdateAccentColorForeground(FrameworkElement element)
    {
        var uiSettings = new UISettings();
        Color c = uiSettings.GetColorValue(UIColorType.Accent);
        element.RequestedTheme = ((5 * c.G + 2 * c.R + c.B) <= 8 * 128)
            ? ElementTheme.Light
            : ElementTheme.Dark;
    }
