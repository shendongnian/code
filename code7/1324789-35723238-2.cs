    var t = new Thread(delegate()
	{
		
		try
		{
			var processInfo = new ProcessStartInfo("cmd.exe", "/c " + cmd);
			processInfo.CreateNoWindow = true;
			processInfo.UseShellExecute = false;
			processInfo.RedirectStandardError = true;
			processInfo.RedirectStandardOutput = true;
			using (Process process = Process.Start(processInfo))
			{
				process.EnableRaisingEvents = true;
				process.OutputDataReceived += (object sender, DataReceivedEventArgs e) => WriteToDebugTextBox(e.Data);
				process.BeginOutputReadLine();
				process.WaitForExit(3000);
                KillChildProcesses(process);
			}
		}
		catch(Exception ex)
		{
			WriteToDebugTextBox(ex.Message);
		}
		WriteToDebugTextBox("Finished Post Process");
	});
	t.Start();
