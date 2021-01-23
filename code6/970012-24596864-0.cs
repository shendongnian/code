    namespace CSharpWPF
    {
        public class ToolTipHelper : DependencyObject
        {
            public static bool GetIsEnabled(DependencyObject obj)
            {
                return (bool)obj.GetValue(IsEnabledProperty);
            }
            public static void SetIsEnabled(DependencyObject obj, bool value)
            {
                obj.SetValue(IsEnabledProperty, value);
            }
            // Using a DependencyProperty as the backing store for IsEnabled.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty IsEnabledProperty =
                DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(ToolTipHelper), new PropertyMetadata(false,OnEnable));
            private static void OnEnable(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                ToolTip t = d as ToolTip;
                DependencyObject parent = t;
                do
                {
                    parent = VisualTreeHelper.GetParent(parent);
                    if(parent!=null)
                        System.Diagnostics.Debug.Print(parent.GetType().FullName);
                } while (parent != null);
                parent = t;
                do
                {
                    //first logical parent is the popup
                    parent = LogicalTreeHelper.GetParent(parent);
                    if (parent != null)
                        System.Diagnostics.Debug.Print(parent.GetType().FullName);
                } while (parent != null);
            
            }  
        }
    }
