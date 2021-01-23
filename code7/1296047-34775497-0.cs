    System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
    pProcess.StartInfo.FileName = @"path\to\gcc";
    pProcess.StartInfo.Arguments = "-Wall myFile.cpp"; //argument
    pProcess.StartInfo.UseShellExecute = false;
    pProcess.StartInfo.RedirectStandardOutput = true;
    pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    pProcess.StartInfo.CreateNoWindow = true; //not diplay a windows
    pProcess.Start();
    string output = pProcess.StandardOutput.ReadToEnd(); //The output result
    int exitCode = pProcess.WaitForExit();
