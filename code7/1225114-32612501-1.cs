    public class MyBevavior
    {
        public static bool GetProperty(DependencyObject obj) => (bool)obj.GetValue(PropertyProperty);
        public static void SetProperty(DependencyObject obj, bool value) => obj.SetValue(PropertyProperty, value);
        public static readonly DependencyProperty PropertyProperty =
            DependencyProperty.RegisterAttached("Property", typeof(bool), typeof(Class), new PropertyMetadata(false, (d, e) =>
            {
                LocalizeDictionary.SetDesignCulture(d, "en");
                ResxLocalizationProvider.SetDefaultAssembly(d, "WPF.Common");
                ResxLocalizationProvider.SetDefaultDictionary(d, "global")
            }));
    }
