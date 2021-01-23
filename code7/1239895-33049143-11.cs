    //protected override void OnStartup(StartupEventArgs e)
    //{
    //    base.OnStartup(e);
    //
    //    TestWindow t = new TestWindow();
    //    t.ShowDialog();
    //}
    private void Application_Startup(object sender, StartupEventArgs e)
	{
		var main = new MainWindow();
		TestWindow t = new TestWindow();
		t.ShowDialog();
		main.Show();
	}
