    public partial class MainWindow : Window
    {
        private MainViewModel _vm;
    
        public MainWindow()
        {
            InitializeComponent();
            _vm = new MainViewModel();
            DataContext = _vm;
        }
    
        private void ButtonRun_OnClick(object sender, RoutedEventArgs e)
        {
            _vm.FolderOrFileName = "FileName" + new Random().Next();
        }
    }
