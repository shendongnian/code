    using System.Windows.Forms.Integration;
    
    namespace MainStartUp.DependencyObjects
    {
        public class FormHostDependencyObject : WindowsFormsHost
        {
            public static readonly DependencyProperty ContentControlProperty =
                DependencyProperty.Register("ContentControl", typeof(System.Windows.Forms.Control), 
                    typeof(FormHostDependencyObject),
                    new PropertyMetadata(new System.Windows.Forms.Control(), PropertyChaged));       
            
            public static void SetContentControl(UIElement element, string value)
            {  
                element.SetValue(ContentControlProperty, value);          
            }
    
            public static string GetContentControl(UIElement element)
            {
                return (string)element.GetValue(ContentControlProperty);
            }
    
            private static void PropertyChaged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
            {
                ((FormHostDependencyObject)dependencyObject).Child = (System.Windows.Forms.Control)e.NewValue;
            }
        }
    }
