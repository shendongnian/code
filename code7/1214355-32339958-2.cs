    public partial class MainWindow : Window
    {
        public MainWindow(YourUserControl userControl)
        {
            InitializeComponent();
            // assuming you have a contentcontrol named 'UserControlViewModel' 
            this.UserControlViewModel.Content = userControl;
        }
        // other code...
    }
