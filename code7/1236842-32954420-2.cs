	string bat_path = "%temp%/temporary_file.bat";
	string command = "command to be executed incl. arguments";
	using (FileStream fs = new FileStream(bat_path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
	using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
	{
		sw.WriteLine("@echo off");
		sw.WriteLine(command);
		sw.WriteLine("PAUSE");
	}
	ProcessStartInfo psi = new ProcessStartInfo() {
		WorkingDirectory = Path.GetDirectoryName(YourApplicationPath),
		RedirectStandardOutput = true,
		RedirectStandardInput = true,
		RedirectStandardError = true,
		CreateNoWindow = false,
		UseShellExecute = false,
		WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
	};
	Process p = new Process() {
		StartInfo = psi;
	};
	p.Start();
	int ExitCode;
	p.WaitForExit();
	// *** Read the streams ***
	string output = p.StandardOutput.ReadToEnd();
	string error = p.StandardError.ReadToEnd();
	ExitCode = p.ExitCode;
	MessageBox.Show("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
	MessageBox.Show("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
	MessageBox.Show("ExitCode: " + ExitCode.ToString(), "ExecuteCommand");
	p.Close();
	File.Delete(bat_path);
