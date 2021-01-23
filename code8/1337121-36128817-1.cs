    public static class Theme
    {
        public static readonly DependencyProperty ThemeProperty =
            DependencyProperty.RegisterAttached("Theme", typeof(string), typeof(Theme), new PropertyMetadata(null, (d, e) =>
            {
                var theme = (string)e.NewValue;
                // in run-time set theme to specified during init
                if (!DesignerProperties.GetIsInDesignMode(d))
                    theme = _theme;
                var element = d as FrameworkElement;
                element.Resources.MergedDictionaries.Clear();
                if (!string.IsNullOrEmpty(theme))
                {
                    var uri = new Uri($"/MyPorject;component/Themes/{theme}.xaml", UriKind.Relative);
                    element.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
                }
            }));
        public static string GetTheme(DependencyObject obj) => (string)obj.GetValue(ThemeProperty);
        public static void SetTheme(DependencyObject obj, string value) => obj.SetValue(ThemeProperty, value);
        static string _theme = "Generic";
        static string[] _themes = new[]
        {
            "Test",
        };
        /// <summary>
        /// Init themes
        /// </summary>
        /// <param name="theme">Theme to use</param>
        public static void Init(string theme)
        {
            if (_themes.Contains(theme))
                _theme = theme;
        }
    }
