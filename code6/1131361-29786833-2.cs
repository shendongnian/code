    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Closed += MainWindow_Closed;
        }
        void MainWindow_Closed(object sender, EventArgs e)
        {
            App.Current.Shutdown();
        }
    }
