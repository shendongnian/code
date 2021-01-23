    private TaskCompletionSource<bool> _storyboardTaskCompletionSource;
    Storyboard _storyboard = new Storyboard();
    private async Task InitAsync()
    {
        _storyboardTaskCompletionSource = new TaskCompletionSource<bool>();
        _storyboard.Begin();
        StartProgress();
        await _storyboardTaskCompletionSource.Task;
        _storyboard.Stop();
    }
    public void StartProgress()
    {
        var bw = new BackgroundWorker();
        bw.DoWork += DoWork;
        bw.RunWorkerCompleted += RunWorkerCompleted;
        bw.RunWorkerAsync();
    }
    private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        _storyboardTaskCompletionSource.SetResult(true);
    }
    private void DoWork(object sender, DoWorkEventArgs e)
    {
        //logic
    }
