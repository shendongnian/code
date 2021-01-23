    public sealed partial class ExampleControl : UserControl
    {
        public static readonly DependencyProperty exampleProperty = DependencyProperty.Register("ExampleData", typeof(Double), typeof(NutritionLabelControl), null);
        public ExampleControl()
        {
            InitializeComponent();
            (this.Content as FrameworkElement).DataContext = this;
        }
        public Double ExampleData
        {
            get { return (Double)GetValue(exampleProperty); }
            set
            {
                SetValue(exampleProperty, value);
            }
        }
    }
