	public static class MyProcess
	{
		public static void LaunchProcess()
		{
			Process myProcess = new Process();
			try
			{
				myProcess.StartInfo.UseShellExecute = false;
				myProcess.StartInfo.FileName = "C:\example.bat";
				myProcess.StartInfo.CreateNoWindow = true;
				myProcess.Start();
				return myProcess;
			}
			catch (Exception e)
			{
				myProcess.Dispose();
				Console.WriteLine(e.Message);
			}
		}
	}
