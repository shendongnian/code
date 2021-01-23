    public DisplayWindow()
    {
        InitializeComponent();
        this.DataContext = SheepViewModel.GetDetails();
    }
