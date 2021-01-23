    DataTable dt = ds.Tables["entry"];
    
    while (dt.Rows.Count * dataGridView1.RowTemplate.Height + dataGridView1.ColumnHeadersHeight < dataGridView1.Height)
    {
        dt.Rows.Add(string.Empty);
    }
    
    dataGridView1.DataSource = dt;
    dataGridView1.Columns["TheBigDataColumnName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
