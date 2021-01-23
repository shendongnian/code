	public partial class App : Application
	{		
		protected override void OnStartup(StartupEventArgs e)
		{
			IocKernel.Initialize(new IocConfiguration());
			base.OnStartup(e);
		}
	}
