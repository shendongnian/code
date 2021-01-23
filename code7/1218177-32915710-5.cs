    public ProfilesViewModel ViewModel = new ProfilesViewModel();
    public ProfilePage()
    {
        this.InitializeComponent();
        this.DataContext = ViewModel;
        ViewModel.Profiles.Add(new Profile { Name = "aaa" });
    }
