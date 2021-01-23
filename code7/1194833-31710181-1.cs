      public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
        
                if (!File.Exists("logindata.xml"))        
                    StatusText = "Just Installed";  
                else
                    StatusText = "Configured"; 
                    
        
                DataContext = this; 
            }
    
        public string StatusText {get;set;}
    }
