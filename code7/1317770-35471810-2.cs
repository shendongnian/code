    public void ThreadSafeClose()
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new Action(Close));  /// or BeginInvoke...
        }
        else
        {
            Close();
        }
    }
