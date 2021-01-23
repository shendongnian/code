    private List<DataDisplay> allDisplayData = new List<DataDisplay>();
    private void applyBtn_Click(object sender, EventArgs e)
    {    
        allDisplayData.Add(new DataDisplay());
    }
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {  
        foreach (var dd in allDisplayData)
        {        
            dd.dataGrid.Items.Refresh();
        }
    }
