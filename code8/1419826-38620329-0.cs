    private async void button1_Click(object sender, EventArgs e)
    {
        await LoadData();
    }
    
    private async Task LoadData()
    {
        for (int i = 0; i < 1001; i++)
        {
            await Task.Delay(5); // useless, increase it to 1000 to notice difference
            workTable.Rows.Add(i, String.Format("Record {0}", i));
    
            this.barEditItem1.EditValue = i;
        }
    }
