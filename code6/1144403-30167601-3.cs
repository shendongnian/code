    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);
    
        if (cts != null)
        {
            cts.Cancel();
        }
    }
