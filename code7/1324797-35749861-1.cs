	var t = new Thread(delegate()
	{
		try
		{
			using (var jobHandler = new Job())
			{
				var processInfo = new ProcessStartInfo("cmd.exe", "/c " + cmd);
				processInfo.CreateNoWindow = true;
				processInfo.UseShellExecute = false;
				processInfo.RedirectStandardError = true;
				processInfo.RedirectStandardOutput = true;
				using (Process process = Process.Start(processInfo))
				{
					DateTime started = process.StartTime;
					jobHandler.AddProcess(process.Id); //add the PID to the Job object
					process.EnableRaisingEvents = true;
					process.OutputDataReceived += (object sender, DataReceivedEventArgs e) => WriteToDebugTextBox(e.Data);
					process.BeginOutputReadLine();
					process.WaitForExit(_postProcessesTimeOut * 1000);
					TimeSpan tpt = (DateTime.Now - started);
					if (Math.Abs(tpt.TotalMilliseconds) > (_postProcessesTimeOut * 1000))
					{
						WriteToDebugTextBox("Timeout reached, terminating all child processes"); //jobHandler.Close() will do this, just log that the timeout was reached
					}
					
				}
                jobHandler.Close(); //this will terminate all spawned processes 
			}
		}
		catch (Exception ex)
		{
			WriteToDebugTextBox("ERROR:" + ex.Message);
		}
		WriteToDebugTextBox("Finished Post Process");
	});
	t.Start();
