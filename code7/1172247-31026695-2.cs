    System.Diagnostics.Process process = new System.Diagnostics.Process();
    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    startInfo.FileName = "cmd.exe";
    startInfo.Arguments = @"/c e:\test\ftp.bat";
    startInfo.RedirectStandardOutput = true;
    startInfo.UseShellExecute = false;
    process.StartInfo = startInfo;
    process.Start();
 
