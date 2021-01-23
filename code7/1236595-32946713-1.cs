    public static class DesignTimeModels
	{
        public static ExampleViewModel ExampleViewModelForDesignTime { get; set; }
		static DocumentEditorViewModelMocks()
		{
            ExampleViewModelForDesignTime = 
                new ExampleViewModel(new EventAggregator(), new WindowManager());
        }
    }
