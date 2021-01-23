    [Bindable]
    public class AttachedPropertyTest
    {
        public static readonly DependencyProperty FooProperty = 
            DependencyProperty.RegisterAttached(
            "Foo", typeof(string), typeof(AttachedPropertyTest), new PropertyMetadata("Hello world!"));
        
        public static void SetFoo(DependencyObject element, string value)
        {
            element.SetValue(FooProperty, value);
        }
        public static string GetFoo(DependencyObject element)
        {
            return (string)element.GetValue(FooProperty);
        }
    }
