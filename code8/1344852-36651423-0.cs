            Process processToKill = Process.GetProcessesByName("OUTLOOK").FirstOrDefault();
			try
			{
                if(processToKill != null)
                {
				    process.Kill();
				    process.WaitForExit();
                }
			}
			catch (Exception ex)
			{
				// Handle exception
			}
