    public MyUserControl(IMyViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
