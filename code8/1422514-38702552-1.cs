    public pgProjects()
    {
        InitializeComponent();
        LoadList(ViewModel.ProjectList);
    }
    public vmProjects ViewModel => (vmProjects)DataContext;
