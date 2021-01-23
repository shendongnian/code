	private void button1_Click(object sender, EventArgs e)
	{
		if (null == System.Windows.Application.Current)
		{
			new System.Windows.Application();
		}
		var wpfwindow = new Window();
		wpfwindow = new WpfCustomControlLibrary1.Window1();
		ElementHost.EnableModelessKeyboardInterop(wpfwindow);
		wpfwindow.Show();
	}
