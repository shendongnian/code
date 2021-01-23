    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = XDocument.Parse(Properties.Resources.XmlFile);
        }
    }
