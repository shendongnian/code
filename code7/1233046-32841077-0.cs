    public partial class MainWindow : Window
    {    
        public CViewModel ViewModel { get; set; }            
        public MainWindow()
        {    
            try
            {
                 InitializeComponent(); // create VM first time
                 try
                 {          
                     DataContext = new CViewModel();
