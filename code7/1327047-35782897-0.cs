    protected override void OnFormClosing(FormClosingEventArgs e) 
    {
        if (e.CloseReason != CloseReason.WindowsShutDown 
        && e.CloseReason != CloseReason.ApplicationExitCall 
        && e.CloseReason != CloseReason.FormOwnerClosing )
        {
            e.Cancel = true;
        }
        base.OnFormClosing(e);
    }
