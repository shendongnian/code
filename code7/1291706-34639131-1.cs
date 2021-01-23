    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (e.CloseReason != CloseReason.ApplicationExitCall
         && e.CloseReason != CloseReason.WindowsShutDown)
         {
              e.Cancel = true;
         }
    }
