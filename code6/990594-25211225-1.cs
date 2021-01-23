    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
    }
    //...
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Window1 test = new Window1();
            test.ShowDialog();
            
            if(test.InvalidLicense)
                Close();
            InitializeComponent();
        }
    }
