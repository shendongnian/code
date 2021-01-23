    public void InvokeCanExecute()
    {
        var handler = CanExecuteChanged;
        if (handler != null)
        {
            handler(this, new EventArgs());
        }
    }
