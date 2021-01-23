    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Range = new DoubleCollection(new double[] { 0.1, 0.2, 0.4, 0.5, 0.6, 0.89, 1.005 });
            InitializeComponent();
        }
        public DoubleCollection Range { get; set; }
    }
