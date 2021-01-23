    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += MainWindow_Closing;
        }
        MainWindowViewModel ViewModel
        {
            get { return (MainWindowViewModel)DataContext; }
        }
        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            var canExit = ViewModel.ShowConfirmExitDlg();
            if (!canExit) e.Cancel = true;
        }
    }
