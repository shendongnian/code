    public partial class MainWindow : Window
    {
        private Color _MyColor;
    
        public Color MyColor
        {
            get { return _MyColor; }
            set { _MyColor = value; }
        }
        
        public MainWindow()
        {            
            InitializeComponent();
            MyColor = Colors.Orange;
            this.DataContext = this;
        }
    
    }
