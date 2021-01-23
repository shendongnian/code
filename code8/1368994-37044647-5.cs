    private void Form1_Load(object sender, EventArgs e)
    {
        DataTable table = new DataTable();
        table.Columns.Add("A");
        table.Columns.Add("B");
        table.Columns.Add("C");
        table.Columns.Add("D");
        table.Columns.Add("E");
        table.Columns.Add("F");
        dataGridView2.DataSource = table;
        DataTable table2 = (DataTable)(dataGridView2.DataSource);
        DataTable tTable = null;
        try
        {
            tTable = GenerateTransposedTable(table2);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        dataGridView2.DataSource = tTable;
        dataGridView2.RowHeadersVisible = true;
        dataGridView2.ColumnHeadersVisible = false;
    }
