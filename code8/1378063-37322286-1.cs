    public MainWindow()
    {
       ViewModelClass.Instance = new ViewModelClass();
       DataContext = viewModel.Instance;
    }
