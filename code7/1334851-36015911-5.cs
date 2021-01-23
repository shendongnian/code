    private async void WaitForXSeconds()
    {
        for (int i = 0; i < 100; i++)
        {
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(60));
            // do something after x seconds!
            // Updates the DB with new/modified data
            LoadDailyButton_Click(null, null);
            BestGrid.DataSource = null;
            BestGrid.DataSource = BestCollection;
            Bestgrid.DataBind();
            string starttime = System.DateTime.Now.ToString();
            CycleResultsListBox.Items.Add("Cycle Started : " + starttime.ToString());
        }
    }
