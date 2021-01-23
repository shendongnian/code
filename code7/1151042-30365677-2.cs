    protected override void OnStop()
    {
        if (host != null)
        {
            host.Close();
            host = null;
        }
    }
