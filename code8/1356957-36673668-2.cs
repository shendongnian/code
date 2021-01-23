        public class Class1
    {
        public static readonly DependencyProperty tbtextProperty = DependencyProperty.RegisterAttached(
    "tbtext", typeof(String), typeof(Class1), new PropertyMetadata(string.Empty));
        public static void Settbtext(UIElement element, String value)
        {
            element.SetValue(tbtextProperty, value);
        }
        public static String Gettbtext(UIElement element)
        {
            return (String)element.GetValue(tbtextProperty);
        }
    }
