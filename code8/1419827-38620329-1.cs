    private async void button1_Click(object sender, EventArgs e)
    {
        await LoadData();
    }
    
    private async Task LoadData()
    {
        for (int i = 0; i < 1001; i++)
        {
            await Task.Delay(5);
            workTable.Rows.Add(i, String.Format("Record {0}", i));
            
            DataTable up = workTable.Clone(); // useless but copied from your code
            this.barEditItem1.EditValue = i;
        }
        gridControl1.DataSource = workTable;
    }
