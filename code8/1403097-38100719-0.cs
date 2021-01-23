    private int deleteCounter = 0;
    private void OnDeleted(object sender, FileSystemEventArgs e)
    {
        //your delete code
        if(deleteCounter % 50 == 0)
        {
            SetBalloonTip("File Eliminato");
            notifyIcon1.ShowBalloonTip(1);
        }
    }
