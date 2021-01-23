    private void Form1_Load(object sender, EventArgs e)
    {
        var dt = new DataTable();
        dt.Columns.Add("C1", typeof(string));
        dt.Columns.Add("C2", typeof(string));
        dt.Rows.Add("1", "11");
        dt.Rows.Add("2", "21");
        dt.Rows.Add("3", "31");
        dt.Rows.Add("1", "12");
        dt.Rows.Add("2", "22");
        dt.Rows.Add("3", "32");
        dt.Rows.Add("1", "13");
        dt.Rows.Add("2", "23");
        this.dataGridView1.DataSource = dt;
        this.dataGridView1.Sort(this.dataGridView1.Columns[0], ListSortDirection.Ascending);
        foreach (DataGridViewColumn column in this.dataGridView1.Columns)
        {
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        this.dataGridView1.CellFormatting += dataGridView1_CellFormatting;
    }
