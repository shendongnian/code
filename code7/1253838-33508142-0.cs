    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Process process = new Process();
        process.OutputDataReceived += ReadOutput;
        process.ErrorDataReceived += ReadErrorOutput;
        process.EnableRaisingEvents = true;
        process.StartInfo = new ProcessStartInfo(Path.Combine(Environment.CurrentDirectory, "BatchFile", "test2.bat"))
        {
            UseShellExecute = false,
            Verb = "runas",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true,
            WorkingDirectory = Path.Combine(Environment.CurrentDirectory, "BatchFile") + "\\",
        };
    
        process.Start();
        process.BeginErrorReadLine();
        process.BeginOutputReadLine();
    
        process.WaitForExit();
    }
