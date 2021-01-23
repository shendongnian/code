    using System.Windows;
    
    namespace DebugTest
    {
        public partial class MainWindow : Window
        {
    
            public static bool GetIsDebugOnly(DependencyObject obj)
            {
                return (bool)obj.GetValue(IsDebugOnlyProperty);
            }
            public static void SetIsDebugOnly(DependencyObject obj, bool value)
            {
                obj.SetValue(IsDebugOnlyProperty, value);
            }
            public static readonly DependencyProperty IsDebugOnlyProperty = DependencyProperty.RegisterAttached("IsDebugOnly", typeof(bool), typeof(MainWindow), new PropertyMetadata(false, new PropertyChangedCallback((s, e) =>
            {
                UIElement sender = s as UIElement;
                if (sender != null && e.NewValue != null)
                {
                    bool value = (bool)e.NewValue;
                    if (value)
                    {
    #if DEBUG
                        bool isDebugMode = true;
    #else
                        bool isDebugMode = false;
    #endif
    
                        sender.Visibility = isDebugMode ? Visibility.Visible : Visibility.Collapsed;
                    }
                }
            })));
    
            public MainWindow()
            {
                InitializeComponent();
            }
        }
    
    }
