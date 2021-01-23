    DataTable originalData;
    private void Form1_Load(object sender, EventArgs e)
    {
        GetData();
        SetDataSource();
        //Set all columns sort mode to Programmatic
        this.dataGridView1.Columns.Cast<DataGridViewColumn>().ToList()
            .ForEach(c => { c.SortMode = DataGridViewColumnSortMode.Programmatic; });
        this.dataGridView1.ColumnHeaderMouseClick += dataGridView1_ColumnHeaderMouseClick;
    }
