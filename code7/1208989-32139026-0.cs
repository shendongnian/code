    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            Loaded += delegate
            {
                Height = ViewModel.YHeight;
                Width = ViewModel.XWidth;
                ViewModel.PropertyChanged += ViewModelOnPropertyChanged;
                SizeChanged += MainWindow_SizeChanged;
            };
            Unloaded += delegate
            {
                ViewModel.PropertyChanged -= ViewModelOnPropertyChanged;
                SizeChanged -= MainWindow_SizeChanged;
            };
           
        }
        public MainWindowViewModel ViewModel
        {
            get { return (MainWindowViewModel)DataContext; }
        }
        private void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "YHeight")
            {
                Height = ViewModel.YHeight;
            }
            if (e.PropertyName == "XWidth")
            {
                Width = ViewModel.XWidth;
            }
        }
        void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ViewModel.XWidth = e.NewSize.Width;
            ViewModel.YHeight = e.NewSize.Height;
        }
    }
