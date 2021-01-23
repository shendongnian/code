    public sealed class CustomHub
    {
		public FrameworkElement Container { get; set; }
		
        public MainView()
        {
            this.InitializeComponent();
        }
		
		private void InitGestureInteraction()
		{
			this.Container = (FrameworkElement)GetTemplateChild("RootGrid");
			this.Container.ManipulationMode = ManipulationModes.TranslateX | ManipulationModes.TranslateRailsX;
			this.Container.ManipulationStarted += (s, e) =>
			{
			};
			this.Container.ManipulationDelta += (s, e) =>
			{
				var x = e.Cumulative.Translation.X;
				// implementation of moving
			};
			this.Container.ManipulationCompleted += (s, e) =>
			{
				var x = e.Cumulative.Translation.X;
				// implementation of moving
			};
		}
    }
