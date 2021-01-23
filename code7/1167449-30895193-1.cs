    var consoleAssemblyLocation = new Uri(typeof(HelperExe).Assembly.CodeBase);
    var file = new FileInfo(consoleAssemblyLocation.LocalPath);
    if (file.Exists)
    {
        var consoleProcess = new Process 
        {
            StartInfo = new ProcessStartInfo(file.FullName)
            {
                CreateNoWindow = true
            }
        };
        consoleProcess.Start();
        var timeout = (int)TimeSpan.FromMinutes(5).TotalMilliseconds;
        consoleProces.WaitForExit(timeout);
    }
