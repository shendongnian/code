    public AgentWindow()
    {
        InitializeComponent();
        // Don't create a **new** VM
        //var agentViewModel = new AgentViewModel();
        // Get your main instance 
        var agentViewModel = AgentViewModel.Instance;
        //binding list itemsource to observable collection
        lstOperations.ItemsSource = agentViewModel.OperationList;
        store view model into data context
        this.DataContext = agentViewModel;
    }
