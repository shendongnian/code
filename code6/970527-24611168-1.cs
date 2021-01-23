    private void ScanEvents()
    {
        if (lblMessage.InvokeRequired)
        {
            lblMessage.Invoke((Action)(() => lblMessage.Text = "This text was placed from within a thread."));
        }
    }
