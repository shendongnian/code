    DataTable table = (DataTable)(dataGridView1.DataSource);
    DataTable tTable = null;
    try
    {
        tTable = GenerateTransposedTable(table);
    }
    catch(Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
    dataGridView1.DataSource = tTable;
    dataGridView1.RowHeadersVisible = true;
    dataGridView1.ColumnHeadersVisible = false;
