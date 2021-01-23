    var myTheme = new Theme("Dark", "DevExpress.Xpf.Themes.Dark")
    {
        AssemblyName = "DevExpress.Xpf.Themes.Dark.v15.1"
    };
    Theme.RegisterTheme(myTheme);
    ThemeManager.ApplicationThemeName = myTheme.Name;
