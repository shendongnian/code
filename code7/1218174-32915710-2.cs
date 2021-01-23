    public ProfileViewModel ViewModel  = new ProfileViewModel();
    public ProfilePage()
    {
        this.InitializeComponent();
        this.DataContext = ViewModel;
        ViewModel.Profiles.Add(new Profile { Name = "aaa" });
    }
