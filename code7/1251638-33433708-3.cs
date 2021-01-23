    void ThemeManager_IsThemeChanged(object sender, OnThemeChangedEventArgs e)
    {
        // handle theme change
        _bubbleSeries.Color  = e.Accent.Resources["AccentColor"];
    }
