    private LauncherViewModel mViewModel;             
    
            public void Initialize()                                          
            {
                var view = new Launcher();
    
                mViewModel = new LauncherViewModel
                {
                    MyObservableCollection = new ObservableCollection<ServerModel>(),
                };
                view.DataContext = mViewModel;
                view.ShowDialog();
    
            }
