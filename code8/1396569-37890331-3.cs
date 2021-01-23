    CancellationTokenSource source = new CancellationTokenSource();
    private async Task SearchDirectories()
    {
        if (source != null)
        {
            //Cancel the previously running instance.
            source.Cancel();
        }
        source = new CancellationTokenSource();
        var foundProgress = new Progress<MyProgress>(/* Some code here*/);
        var totalProgress = new Progress<int>(numberofdirs =>
        {
                label1.Text = numberofdirs.ToString();
                label1.Visible = true;
        });
        try
        {
            _stopwatch.Restart();
            await Task.Run(() => DirSearch(@"d:\c-sharp", "*.cs", "Form1", source.Token, foundProgress, totalProgress), source.Token);
            _stopwatch.Stop();
            //Do any code here you had in BackgroundWorker.RunWorkerCompleted
        }
        catch (OperationCanceledException)
        {
            //Do any special code here if it was canceled.
        }
    }
    private void DirSearch(string root, string filesExtension, string textToSearch, CancellationToken token, IProgress<MyProgress> foundProgress, IProgress<int> totalProgress)
    {
        int numberoffiles = 0;
        int numberofdirs = 0;
        string[] filePaths = Directory.GetFiles(root, filesExtension, SearchOption.AllDirectories);
        for (int i = 0; i < filePaths.Length; i++)
        {
            token.ThrowIfCancellationRequested();
                
            int var = File.ReadAllText(filePaths[i]).Contains(textToSearch) ? 1 : 0;
            if (var == 1)
            {
                string filename = filePaths[i];
                numberoffiles++;
                var prog = new MyProgress { Report1 = filename, Report2 = numberoffiles.ToString() };
                foundProgress.Report(prog);
            }
            numberofdirs++;
            totalProgress.Report(numberofdirs);
        }
    }
