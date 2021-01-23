    protected override void OnClosed(EventArgs e)
    {
        GlobalSession.Dispose();
        base.OnClosed(e);
    }
