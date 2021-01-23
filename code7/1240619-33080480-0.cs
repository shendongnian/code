    public static class WindowsFormsHostMap
    {
        public static readonly DependencyProperty TextProperty
            = DependencyProperty.RegisterAttached("Text", typeof(string), typeof(WindowsFormsHostMap), new PropertyMetadata(propertyChanged));
        public static string GetText(WindowsFormsHost o)
        {
            return (string)o.GetValue(TextProperty);
        }
        public static void SetText(WindowsFormsHost o, string value)
        {
            o.SetValue(TextProperty, value);
        }
        static void propertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var t = (sender as WindowsFormsHost).Child as Scintilla;
            if(t != null) t.Text = Convert.ToString(e.NewValue);
        }
    }
