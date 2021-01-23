	public partial class App
	{
		private IKernel _iocKernel;
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			_iocKernel = new StandardKernel();
			_iocKernel.Load(new YourModule());
			Current.MainWindow = _iocKernel.Get<MainWindow>();
			Current.MainWindow.Show();
		}
	}
