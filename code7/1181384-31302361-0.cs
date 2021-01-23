    bool dialogOpen = false;
    public void OpenDialogAndCloseMe()
    {
        var ofd = new OpenFileDialog();
        Thread th = new Thread(() => CloseMe());
        th.Start();
        dialogOpen = true;
        ofd.ShowDialog(this);
        dialogOpen = false;
    }
    private void OnClosing(object sender, CancelEventArgs e)
    {
        //check if OpenFileDialog is still open and block the close...
        if(dialogOpen)
        {
            e.Cancel = true;
        }
    }
