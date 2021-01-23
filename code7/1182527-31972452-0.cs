    public partial class MainMenu : Form
    {
  
        private SplashScreen splash = new SplashScreen();
        
        public MainMenu ()
        {
            InitializeComponent();
            Task.Factory.StartNew(() => {
                splash.ShowDialog();
            });
           Thread.Sleep(2000);
       }
