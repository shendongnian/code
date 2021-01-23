    public class AppBootstrapper : BootstrapperBase
    {
        // ...
        protected override void Configure()
        {
            container.Singleton<IWindowManager, WindowManager>();
        }
    }
	public class CallingViewModel
	{
		private readonly IWindowManager windowManager;
		public CallingViewModel(IWindowManager windowManager)
		{
			this.windowManager = windowManager;
  		}
		public Method()
		{
			var called = new CalledViewModel();
			var result = windowManager.ShowDialog(called);
            // handle result
		}
    }
	public class CalledViewModel : Screen
	{
		public void Ok()
		{
			TryClose(true);
		}
		public void Cancel()
		{
			TryClose(false);
		}
    }
