    protected CancellationTokenSource CancellationToken { get; private set; }
    protected void SetDescPoint(object sender, EventArgs e)
    {
        try
        {
            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
            this.CancellationToken = new CancellationTokenSource();
            Task.Run(() => foo(this.CancellationToken.Token), this.CancellationToken.Token);
        }
        catch (Exception)
        { }
    }
    private async Task foo(CancellationToken token)
    {
        try
        {
            System.Diagnostics.Debug.WriteLine("Start - " + DateTime.Now.ToString("h:mm:ss tt"));
            TimeSpan minutes = TimeSpan.FromMinutes(10);
            await Task.Delay(minutes, token);
            string path = UniquePath();
            File.Delete(path);
            System.Diagnostics.Debug.WriteLine("Deleted - " + DateTime.Now.ToString("h:mm:ss tt"));
        }
        catch (Exception ex)
        {
            Debug.WriteLine("EXCEPTION - " + ex.Message);
        }
    }
