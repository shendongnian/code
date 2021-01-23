    private void SelectTime(int val)
    {
        try
        {
            CurrentIndex = val;
            lstData.Items[CurrentIndex].Selected = true;
            lstData.EnsureVisible(CurrentIndex);
    
            String text = lstData.Items[CurrentIndex].Text;
            MessageBox.Show("Time Selected: " + text);
    
            //Get the closest DateTime to the Current item of lstData
            DateTime MinimumDifferenceItem = lstReport.Items.Cast<DateTime>().OrderBy(Dt => Math.Abs((Dt - (DateTime)lstData.Items[CurrentIndex]).Milliseconds)).First();
    
            this.Refresh();
        }
        catch { }
    }
