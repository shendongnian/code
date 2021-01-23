    private void _FileCountingWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        if (!Dispatcher.CheckAccess()) // CheckAccess returns true if you're on the dispatcher thread
        {
            Dispatcher.Invoke(new Action<object, ProgressChangedEventArgs>(_FileCountingWorker_ProgressChanged), sender, e);
            return;
        }
        if (typeof(object[]) == e.UserState.GetType())
        {
            object[] StatusMsg = (object[])e.UserState;
            if (6 == StatusMsg.GetLength(0))
            {
                if (StatusMsg[5] != null)
                {
                    lblCountingFiles.Text = StatusMsg[5].ToString();
                }
            }
        }
    }
