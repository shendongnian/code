    internal partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
    
            this.DataContext = new ProgramModel();
        }
    }
