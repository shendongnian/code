    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var v = new ViewModel();
            this.DataContext = v;
        }
     }
    
