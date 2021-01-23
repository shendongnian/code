	public class MyProcess : IDisposable
	{
		private Process myProcess = null;
		
		~MyProcess()
		{
			Dispose(false);
		}
		
		public void Dispose(bool dispose)
		{
			Dispose();
		}
		
		public void Dispose()
		{
			if (myProcess != null)
			{
				if (!myProcess.HasExited)
					myProcess.Kill();
				myProcess.Dispose();
				myProcess = null;
			}
		}
	
		public bool LaunchProcess()
		{
			try
			{
				myProcess = new Process();
				myProcess.StartInfo.UseShellExecute = false;
				myProcess.StartInfo.FileName = "C:\example.bat";
				myProcess.StartInfo.CreateNoWindow = true;
				myProcess.Start();
				return true;
			}
			catch (Exception e)
			{
				myProcess.Dispose();
				Console.WriteLine(e.Message);
			}
			return false;
		}
	}
