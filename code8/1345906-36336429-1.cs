	void LaunchAndWaitForProcess(object sender, RoutedEventArgs routedEventArgs)
	{
		this.ContextMenu.Closed -= LaunchAndWaitForProcess;
		Process p = new Process();
		p.StartInfo.FileName = "notepad.exe";
		p.StartInfo.CreateNoWindow = false;
		p.Start();
		p.WaitForExit();
		p.Close();
	}
	void MyMenuItem_Click(object sender, RoutedEventArgs e)
	{
		this.ContextMenu.Closed += LaunchAndWaitForProcess;
	}
