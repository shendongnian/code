    public class VehicleView : UserControl
    {
        // Year
        public static readonly DependencyProperty YearProperty =
            DependencyProperty.Register("Year", typeof(int), typeof(VehicleView),
                new PropertyMetadata());
        public int Year
        {
            get { return (int)GetValue(YearProperty); }
            set { SetValue(YearProperty, value); }
        }
        // Make
        public static readonly DependencyProperty MakeProperty =
            DependencyProperty.Register("Make", typeof(string), typeof(VehicleView),
                new PropertyMetadata("None"));
        public string Make
        {
            get { return (string)GetValue(MakeProperty); }
            set { SetValue(MakeProperty, value); }
        }
        // Model
        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register("Model", typeof(string), typeof(VehicleView),
                new PropertyMetadata("None"));
        public string Model
        {
            get { return (string)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }
        public VehicleView()
        {
            InitializeComponent();
        }
    }
