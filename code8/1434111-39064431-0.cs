    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DC();
        }
        public class DC
        {
            public string str { get; set; }
    
            public DC()
            {
                str = "OK";
            }
        }
    }
