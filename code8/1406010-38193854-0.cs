    var process = new Process();
    var startInfo = new ProcessStartInfo();
    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
    startInfo.FileName = processName; //cmd
    startInfo.Arguments = string.Format(processArgument, "tmp.txt");
    startInfo.RedirectStandardOutput = true;
    startInfo.RedirectStandardError = true;
    startInfo.UseShellExecute = false;
    process.StartInfo = startInfo;
    process.Start();
    string outputText = process.StandardOutput.ReadToEnd(); // Check this
    string errorText = process.StandardError.ReadToEnd();   // Check this
    int exitCode = process.ExitCode;                        // Check this
    process.WaitForExit();
    // In outputText is probably something here...
    // In errorText is probably something here...
    // In exitCode is probably something here...
