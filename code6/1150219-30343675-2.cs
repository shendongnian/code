    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        if (!backgroundWorker1.CancellationPending)
        {
            Status result = (Status)e.UserState;
            Complete_label.Visible = true;
            var newItem=listView1.Items.Add("");
            newItem.SubItems.Add(result.SystemName);
            newItem.SubItems.Add(result.StatusString);
            newItem.SubItems.Add(result.AvailableUpdatesCount.ToString());
            //other stuff
        }
    }    
