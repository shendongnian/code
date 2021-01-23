    private static SolidColorBrush ToBrush(ThemeResourceKey key)
    {
        var color = VSColorTheme.GetThemedColor(key);
        return new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
    }
