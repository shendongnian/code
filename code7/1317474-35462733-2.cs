    System.Diagnostics.Process process = new System.Diagnostics.Process();
    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    startInfo.FileName = "python.exe";
    startInfo.Arguments = "-c import foo; print foo.hello()";
    process.StartInfo = startInfo;
    process.Start();
