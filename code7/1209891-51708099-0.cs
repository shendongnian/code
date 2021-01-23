    public List<string> myCollection { get; set; }
    
        public MainWindow()
        {            
            myCollection = new List<string> {"test1", "test2", "test3", "test4"};
            DataContext = this;
    
            InitializeComponent(); //-- call it at the end
        }
