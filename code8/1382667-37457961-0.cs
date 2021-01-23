        const int MAX_EXIT_WAIT_TIME = 3000;
        // Fill needed data
        string username = "";
        string password = "";
        string domain = "";
        string appName = "";
    
        var dir = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        var appFullPath = Path.Combine(dir, appName);
        ProcessStartInfo psi = new ProcessStartInfo(appFullPath);
        psi.UserName = username;
        var securePass = new System.Security.SecureString();
        foreach (var c in password)
            securePass.AppendChar(c);
        psi.Password = securePass;
        psi.Domain = domain;
        psi.LoadUserProfile = false;
        psi.WorkingDirectory = dir;
        psi.Arguments = "";
        psi.RedirectStandardOutput = true;
        // Create Process object, but not start it!
        var proc = new Process();
        proc.StartInfo = psi;
        StringCollection values = new StringCollection();
        DataReceivedEventHandler outputDataReceived = (o, e) =>
        {
            lock (values)
                values.Add(e.Data);
        };
        try
        {
            proc.OutputDataReceived += outputDataReceived;
            // Only here we start process
            if (!proc.Start())
                throw new InvalidOperationException("Couldn't start app");
            proc.BeginOutputReadLine();
            proc.WaitForExit(MAX_EXIT_WAIT_TIME);
        }
        finally { proc.OutputDataReceived -= outputDataReceived; }
        Console.WriteLine("Read {0} ", values.Count);
        foreach (var item in values)
            Console.WriteLine("  {0}", item);
