    public class YourCustomControl : Control
    {
        public static readonly DependencyProperty TestPropProperty =
            DependencyProperty.Register("TestProp", typeof(string), typeof(TestControl), new UIPropertyMetadata(null));
    
        public string TestProp
        {
            get { return (string)GetValue(TestPropProperty); }
            set { SetValue(TestPropProperty, value); }
        }
    
        static YourCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TestControl), new FrameworkPropertyMetadata(typeof(TestControl)));
        }
    }
