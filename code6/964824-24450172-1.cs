    Process pdfProcess = new Process();
	pdfProcess.StartInfo.FileName = filePath;
	if (pdfProcess.Start())
	{
		Thread.Sleep(500);
		Process[] processlist = Process.GetProcesses();
		string windowTitle = string.Empty;
		foreach (Process process in processlist)
		{
			if (!String.IsNullOrEmpty(process.MainWindowTitle) && process.MainWindowTitle.Contains(fileName))
			{
				windowTitle = process.MainWindowTitle;
			}
		}
		IntPtr pdfHandle = FindWindow(null, windowTitle);
		while (IsWindow(pdfHandle) && userExitedApp == false)
			Thread.Sleep(100);
	}
