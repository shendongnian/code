    public static class StylingLookup
    {
        public static Color GetColour(string key)
        {
            var currentTheme = (Application.Current.Resources["CurrentTheme"] as Theme);
            return currentTheme.Colours["key"];
        }
    }
