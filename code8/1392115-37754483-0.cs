    public partial class MainWindow : Window
    {
        OuterViewModel _vm;
        public MainWindow()
        {
            InitializeComponent();
            _vm = new OuterViewModel();
            _vm.Init();
            DataContext = _vm;
        }
    }
