    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        Process process = new Process();
        TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
        process.OutputDataReceived += ReadOutput;
        process.ErrorDataReceived += ReadErrorOutput;
        process.Exited += (sender, e) => tcs.SetResult(true);
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
    
        bool result = await tcs.Task;
        // Do your additional post-process work here
    }
