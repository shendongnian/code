    using System.Diagnostics;
	public void GetProcessesInfo()
	{
		Process[] allProcesses = Process.GetProcesses();
		foreach (Process process in allProcesses)
		{
			try
			{
				string windowName = process.MainWindowTitle;
				TimeSpan duration = DateTime.Now - process.StartTime;
				process.EnableRaisingEvents = true;
				process.Exited += new EventHandler(process_Exited);
			}
			catch(System.ComponentModel.Win32Exception)
			{
				//access to that process was denied
			}
		}
	}
	void process_Exited(object sender, EventArgs e)
	{
		//a process has exited
	}
