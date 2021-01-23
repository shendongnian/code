    RadGridView radGridView1 = new RadGridView();
    this.Controls.Add(radGridView1);
    radGridView1.Dock = DockStyle.Fill;
    DataTable table = new DataTable();
    table.Columns.Add("col1");
    table.Columns.Add("col2");
    table.Rows.Add("value1", "value1");
    table.Rows.Add("value2", "value2");
    
    radGridView1.DataSource = table;
