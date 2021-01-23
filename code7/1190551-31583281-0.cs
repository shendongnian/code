    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            this.del = this.EventHandler; <-- This does not build
        }
    
        public void EventHandler(object sender, PropertyChangedEventArgs e)
        {
    
        }
    
        public delegate void A(object sender, PropertyChangedEventArgs e);
    
        private A del;
    }
