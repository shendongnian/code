        public Container DryContainer { get; private set; }
	    public App()
	    {
            DryContainer = new Container(rules => rules.WithoutThrowOnRegisteringDisposableTransient());
            DryContainer.Register<IDatabaseManager, DatabaseManager>();
	        DryContainer.Register<IJConfigReader, JConfigReader>();
	        DryContainer.Register<IMainWindowViewModel, MainWindowViewModel>(
                Made.Of(() => new MainWindowViewModel(Arg.Of<IDatabaseManager>(), Arg.Of<IJConfigReader>())));
	        DryContainer.Register<MainWindow>();
        }
