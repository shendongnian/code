    protected override OnFormClosing( object sender , FormClosingEventArgs e )
    {
      base.OnFormClosing( sender , e );
    
      // Cancel's the closing and keeps the form alive
      e.Cancel = _worker.IsBusy;
    }
    
    private void RunWorkerCompleted( object sender , RunWorkerCompletedEventArgs e)
    {
      // Work is done, so close the form
      Close();
    }
