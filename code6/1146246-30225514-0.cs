    public partial class userControl : UserControl
    {
        public userControl()
        {
            InitializeComponent();
            DependencyPropertyDescriptor descriptor = DependencyPropertyDescriptor.FromProperty(FrameworkElement.IsMouseOverProperty, typeof(FrameworkElement));
            descriptor.AddValueChanged(this.innerControl, new EventHandler(OnIsMouseOverChanged));
          
        }
        // Dependency Property Declaration
        private static DependencyPropertyKey ElementIsMouseOverPropertyKey = DependencyProperty.RegisterReadOnly("ElementIsMouseOver", typeof(bool),typeof(userControl), new PropertyMetadata());
        public static DependencyProperty ElementIsMouseOverProperty = ElementIsMouseOverPropertyKey.DependencyProperty;
        public bool ElementIsMouseOver
        {
            get { return (bool)GetValue(ElementIsMouseOverProperty); }
        }
        private void SetIsMouseOver(bool value)
        {
            SetValue(ElementIsMouseOverPropertyKey, value);
        }
        // Dependency Property Callback
        // Called when this.MyElement.ActualWidth is changed
        private void OnIsMouseOverChanged(object sender, EventArgs e)
        {
            this.SetIsMouseOver(this.innerControl.IsMouseOver);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.innerControl.Width += 10;
        }
    }
