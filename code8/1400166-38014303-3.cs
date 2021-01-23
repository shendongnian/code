    public partial class MainWindow : Window, IMainWindow
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel(this);
            InitializeComponent();
        }
    }
    public interface IMainWindow
    {
        void Close();
    }
    public class MainWindowViewModel
    {
        private readonly IMainWindow _mainWindow;
        public MainWindowViewModel() : this(null)
        {
            // Design time
        }
        public MainWindowViewModel(IMainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            CmdCloseApp = new RelayCommand(CloseApp);
        }
        public ICommand CmdCloseApp { get; set; }
        public void CloseApp(object parameter)
        {
            _mainWindow.Close();
        }
    }
