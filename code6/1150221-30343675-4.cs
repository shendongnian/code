    private void ReportServerProgress(StatusProgress result)
    {
        Complete_label.Visible = true;
        var newItem=listView1.Items.Add("");
        newItem.SubItems.Add(result.SystemName);
        newItem.SubItems.Add(result.StatusString);
        newItem.SubItems.Add(result.AvailableUpdatesCount.ToString());
        //other stuff
    }   
    CancellationTokenSource _cts;
    Progress<StatusProgress> _progress;
    public void StartProcessiong()
    {
        _cts=new CancellationTokenSource();
       _progress=new Progress<StatusProgress(progress=>ReportServerProgress(progress);
       StartProcessing(/*input*/,_cts.Token,_progress);
    }
    public void CancelLoop()
    {
       if (_cts!=null)
          _cts.Cancel();
    }
