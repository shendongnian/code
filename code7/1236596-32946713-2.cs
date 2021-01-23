    public static class DesignTimeModels
	{
        public static ExampleViewModel ExampleViewModelForDesignTime { get; set; }
        // static constructor
		static DesignTimeModels()
		{
            ExampleViewModelForDesignTime = 
                new ExampleViewModel(new EventAggregator(), new WindowManager());
        }
    }
