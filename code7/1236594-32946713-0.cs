    public static class DocumentEditorViewModelMocks
	{
        public static ExampleViewModel ExampleViewModelForDesignTime { get; set; }
		static DocumentEditorViewModelMocks()
		{
            ExampleViewModelForDesignTime = 
                new ExampleViewModelForDesignTime(new EventAggregator(), new WindowManager());
        }
    }
