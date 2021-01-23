    private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
    {
        var theme = ThemeManager.DetectAppStyle(Application.Current);
        var accent = ThemeManager.GetAccent("MyCustomAccent");
        ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);
    }
