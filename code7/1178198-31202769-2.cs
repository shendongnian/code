    public partial class MainWindow : Form
    {
        protected MainWindow mainWindow;
    
        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;
        }
    //smth
    }
    
    class Downloader : MainWindow
    {
        
        public Downloader()
        {
            //this.mainWindow //will give you reference to main winsow
        }
    // smth
    }
