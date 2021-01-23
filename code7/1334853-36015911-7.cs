    for (int i = 0; i< 100; i++)
    {
        await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(60));
        // do something after x seconds!
        // Updates the DB with new/modified data
        LoadDailyButton_Click(null, null);
    
        gridControl1.BeginUpdate();
    
        BestGrid.DataSource = null;
        BestGrid.DataSource = BestCollection;
    
        gridControl1.EndUpdate();
    
        string starttime = System.DateTime.Now.ToString();
        CycleResultsListBox.Items.Add("Cycle Started : " + starttime.ToString());
    }
