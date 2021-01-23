    private void UpdateStatus(String message)
    {
        if (this.InvokeRequired)
            this.Invoke((MethodInvoker)delegate
            {
                UpdateStatus(message);
            });
        else
            label1.Text = message;
    }
