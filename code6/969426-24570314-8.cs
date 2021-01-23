    public void UpdateStatus(string status)
    {
        if (this.Dispatcher.CheckAccess())
            this.status_textblock = status;
        else
            this.Dispatcher.Invoke(new Action<string>(UpdateStatus), status);
    }
