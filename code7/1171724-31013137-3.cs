    public class TextConv: DependencyObject
    {
        public static readonly DependencyProperty TextProperty = 
        DependencyProperty.RegisterAttached(
          "Text",
          typeof(string),
          typeof(TextConv),
          new PropertyMetadata(null, OnValueChanged)
        );
        public static void SetText(UIElement element, string value)
        {
            element.SetValue(TextProperty, value);
        }
        public static string GetText(UIElement element)
        {
            return (string)element.GetValue(TextProperty);
        }
        private static void OnValueChanged(DependencyObject obj,  DependencyPropertyChangedEventArgs args)
       {
           obj.SetValue(TextBlock.TextProperty, args.NewValue.ToString() + "Hello!");
       }
    }
