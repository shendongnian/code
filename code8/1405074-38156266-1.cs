    public partial class MainWindow : Window
    {
        public String txtEmail;
        public MainWindow()
        {
        InitializeComponent();
        }
        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void Login(String txtEmail, String Password)
        {
            this.txtEmail = txtEmail;
        }
    }
