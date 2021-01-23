    // Use system provided icon
    AppBarButton.Icon = new SymbolIcon(Symbol.Cancel);
    
    // Use custom font icon
    AppBarButton.Icon = new FontIcon()
    {
        FontFamily = new Windows.UI.Xaml.Media.FontFamily("Your font"),
        Glyph = "glype"
    };
    
