    public partial class ThreeStateComboBox : UserControl
    {
        public ThreeStateComboBox()
        {
            InitializeComponent();
        }
        public bool? Value
        {
            get { return (bool?)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value",
            typeof(bool?),
            typeof(ThreeStateComboBox),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    }
