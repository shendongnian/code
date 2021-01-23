    public partial class MainWindow : Form
    {
        protected string Bar { get; set; }
        public MainWindow()
        {
            Bar = "bar";
            InitializeComponent();
        }
    }
    public class Downloader : MainWindow
    {
        public void Foo()
        { 
           // Access bar:
           Console.WriteLine(Bar);
        }
    }
