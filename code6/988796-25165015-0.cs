    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e) {
            string inputParam = "some value";
            string outputValue;
            TestDialog dlg = new TestDialog(inputParam);
            if (dlg.ShowDialog() == true)
                outputValue = dlg.OutputParam;
        }
    }
    public partial class TestDialog : Window
    {
        public TestDialog() {
            InitializeComponent();
        }
        public TestDialog(string inputParam) {
            InitializeComponent();
            OutputParam = inputParam.ToUpper(); // for example
        }
        public string OutputParam { get; private set; }
        private void btnOK_Click(object sender, RoutedEventArgs e) {
            DialogResult = true;
        }
    }
