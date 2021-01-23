    public void AddMessageLog(string message)
    {
        Action addLog = () => lstLogs.Items.Add(message).EnsureVisible();
        if (InvokeRequired)
            Invoke(addLog);
        else
            addLog();
    }
