    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new SampleClass() { Message = "My Message" };
        }       
    }
    public class SampleClass
    {
        public string Message { get; set; }
    }
