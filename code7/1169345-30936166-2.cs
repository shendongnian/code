    public static class CheckBoxExtensions
    {
        public static void SetDefaultValue(CheckBox element, bool value)
        {
            element.SetValue(DefaultValueProperty, value);
        }
        public static bool GetDefaultValue(CheckBox element)
        {
            return (bool)element.GetValue(DefaultValueProperty);
        }
        // Using a DependencyProperty as the backing store for DefaultValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DefaultValueProperty =
            DependencyProperty.RegisterAttached("DefaultValue", typeof(bool), typeof(CheckBoxExtensions), new UIPropertyMetadata(false));
    }
