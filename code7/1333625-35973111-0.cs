    public Shell()
    {
        InitializeComponent();
        this.ModuleManager.LoadModuleCompleted +=
                 (s, e) =>
                               { 
                               ---------(do not execute)-----------
                                   if (e.ModuleInfo.ModuleName == EmailModuleName)
                                   {
                                       this.RegionManager.RequestNavigate(
                                           "MainContentRegion",
                                           InboxViewUri);
                                   }
                               };
    }
