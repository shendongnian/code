    public partial class CustomLabel : UserControl
    {
        public CustomLabel ()
        {            
            InitializeComponent();
        }
    
        public string Value
        {
            get { return GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
    
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(CustomLabel), new PropertyMetadata(""));
    }
