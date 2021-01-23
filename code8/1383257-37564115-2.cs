    SMySqlDataAdapter adapter = new MySqlDataAdapter(query, connString);
    DataTable table = new DataTable();
    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
    adapter.Fill(table);
    e.Result = table;
    dataGridView1.AutoGenerateColumns = false;
    dataGridView1.DataSource = table;
    DataGridViewColumn(table.Columns[0].ColumnName, new DataGridViewTextBoxColumn());
    DataGridViewColumn(table.Columns[1].ColumnName, new DataGridViewTextBoxColumn());
    DataGridViewColumn(table.Columns[2].ColumnName, new DataGridViewTextBoxColumn());
    DataGridViewColumn(table.Columns[3].ColumnName, new CalendarColumn());//Create the CalendarColumn class as MSDN suggested
    
    private void DataGridViewColumn(string colName, DataGridViewColumn colType)
    {
        colType.DataPropertyName = colName;
        colType.HeaderText = colName;
        colType.Name = colName;
        dataGridView1.Columns.Add(colType);
    }
