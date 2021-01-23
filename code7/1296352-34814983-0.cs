    private async void GetData()
    {    
        tabControl1.TabPages.Clear();
        Task<List<string>> dataSetNames = Task<List<string>>.Factory.StartNew(logic.GetDataSetNames);
        
        await dataSetNames;
        foreach (var dataSetName in dataSetNames.Result)
        {
            Task<DataTable> sourceTable = Task<DataTable>.Factory.StartNew(() => logic.GetDataSet(dataSetName));
            TabPage page = new TabPage { Name = dataSetName }
            DataGridView dgv = new DataGridView { Dock = DockStyle.Fill }
            
            dgv.DataSource = await sourceTable;
            page.Controls.Add(dgv);
            tabControl1.TabPages.Add(page);
        }
    }
