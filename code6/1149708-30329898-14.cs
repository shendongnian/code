    public class IronPythonControl : ContentControl 
    {
        public static readonly DependencyProperty ControlNameProperty =
                               DependencyProperty.Register("ControlName", typeof(string), typeof(IronPythonControl), new FrameworkPropertyMetadata("IronTextBlock", ControlNameChangedCallback));
        private static void ControlNameChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            Content = LoadControl(ControlName);
        }
        public string ControlName
        {
            get { return (string)GetValue(ControlNameProperty); }
            set { SetValue(ControlNameProperty, value); }
        }
        public FrameworkElement LoadControl(string name){/*Load XAML Control from database here*/}
    }
