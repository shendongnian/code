    var proc = new Process();
    proc.StartInfo.WorkingDirectory = path;
    proc.StartInfo.FileName = "my_exe.exe";
    proc.StartInfo.Arguments = "my_args";
    proc.StartInfo.UseShellExecute = false;
	
    var proc2 = new Process();
    proc2.StartInfo.WorkingDirectory = path;
    proc2.StartInfo.FileName = "my_exe2.exe";
    proc2.StartInfo.Arguments = "my_args";
    proc2.StartInfo.UseShellExecute = false;
	
    proc.Start();
    proc2.Start();
	
    proc.WaitForExit();
	proc2.WaitForExit();
	
    if (proc.ExitCode != 0)
    {
        return proc.ExitCode;
    }
    if (proc2.ExitCode != 0)
    {
        return proc2.ExitCode;
    }
	
	return 0;
