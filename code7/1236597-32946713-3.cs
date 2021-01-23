    // static constructor
    static DesignTimeModels()
	{
        var eventAggregator = ServiceLocator.Get<IEventAggregator>();
        var windowManager = ServiceLocator.Get<IWindowManager>();
        ExampleViewModelForDesignTime = 
            new ExampleViewModel(eventAggregator , windowManager);
    }
