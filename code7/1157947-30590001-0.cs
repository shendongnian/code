    public Form1()
    {
        InitializeComponent();
        // ToDo: Refactor this into a method that will be called
        //       on some kind of event (eg. button click).
        var rootFolder = @"D:\Root";
        var outputFolder = Path.Combine(rootFolder, @"\Bin\Release");
        var solutions = GetAvailableSolutions(rootFolder);
        var arguments = solutions.Select(solution => String.Join(" ", solution, "/build Release", "/out " + outputFolder));
        var processes = arguments.Select(CreateMsBuildProcess);
        var worker = new BackgroundWorker();
        worker.DoWork += OnWorkerDoWork;
        worker.ProgressChanged += OnWorkerProgressChanged;
        worker.RunWorkerCompleted += OnWorkerRunWorkerCompleted;
        worker.WorkerSupportsCancellation = true;
        worker.WorkerReportsProgress = true;
        // ToDo: Disable start button
        ClearFolder(outputFolder);
        worker.RunWorkerAsync(processes);
    }
    private IEnumerable<String> GetAvailableSolutions(String rootFolder)
    {
        // ToDo: Change retrieving of .sln files to any logic you alike.
        return Directory.EnumerateFiles(rootFolder, "*.sln", SearchOption.AllDirectories);
    }
    private void OnWorkerDoWork(object sender, DoWorkEventArgs e)
    {
        var index = 0;
        var worker = (BackgroundWorker)sender;
        // ToDo: Give in a self created class instead of process to easier
        //       access the needed text for ReportProgress().
        var processes = (IEnumerable<Process>)e.Argument;
        foreach (var process in processes)
        {
            if (worker.CancellationPending)
                break;
            worker.ReportProgress(index, process.StartInfo.Arguments);
            process.Start();
            process.WaitForExit();
        }
    }
    private void OnWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        var text = (String)e.UserState;
        // ToDo: Update label and progress bar.
        // Eg. label.Text = text; progressBar.PerformStep(); or progressBar.Value = e.ProgressPercentage;
    }
    private void OnWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // ToDo: Enable Start button.
        // Eg. buttonStart.Enabled = true;
    }
    private static void ClearFolder(String folder)
    {
        if (Directory.Exists(folder))
            Directory.Delete(folder, true);
        Directory.CreateDirectory(folder);
    }
    private static Process CreateMsBuildProcess(String arguments)
    {
        var devEnvPath = Path.Combine(Environment.GetEnvironmentVariable("VS100COMNTOOLS"), @"..\IDE\devenv.exe");
        var startInfo = new ProcessStartInfo
        {
            UseShellExecute = false,
            CreateNoWindow = true,
            Arguments = arguments,
            FileName = devEnvPath
        };
        var process = new Process { StartInfo = startInfo };
        return process;
    }
