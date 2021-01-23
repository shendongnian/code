     public partial class MainWindow
            
        {
            public ICommand SaveCommand { get; set; }
            public MyInputData InputData { get; set; }
            public MainWindow()
            {
                InputData = new MyInputData();
                SaveCommand = new MyCommand(InputData, ExecuteAction);
                InitializeComponent();
    
                Loaded += (s, a) => { DataContext = this; }; 
            }
    
            private void ExecuteAction()
            {
                //do save
            }
        }
