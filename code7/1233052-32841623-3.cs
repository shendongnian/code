    public MainWindow()
    {
      InitializeComponent();
      ViewModel = new CViewModel();
      ViewModel.topGrid = TopGrid;
    }
