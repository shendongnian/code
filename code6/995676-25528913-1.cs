    public partial class MainWindowView
    {
        public MainWindowView()
        {
            var mainWindowViewModel = IoC.GetInstance<IMainWindowViewModel>();
            //Do other configuration            
            
            DataContext = mainWindowViewModel;
            InitializeComponent();
        }
    }
