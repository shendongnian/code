    SMySqlDataAdapter adapter = new MySqlDataAdapter(query, connString);
    DataTable table = new DataTable();
    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
    adapter.Fill(table);
    e.Result = table;
    dataGridView1.AutoGenerateColumns = false;
    dataGridView1.DataSource = table;
    DataGridViewColumn col = new DataGridViewTextBoxColumn();
    col.DataPropertyName = "Id";
    col.HeaderText = "ID";
    col.Name = "Id";
    //////////////////////////////////////////
    DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
    col2.DataPropertyName = "Name";
    col2.HeaderText = "Name";
    col2.Name = "Name";            
    //////////////////////////////////////////
    CalendarColumn col3 = new CalendarColumn();//Create this class as MSDN suggested
    col3.DataPropertyName = "BirthDate";
    col3.HeaderText = "BirthDate";
    col3.Name = "BirthDate";
    dataGridView1.Columns.AddRange(col,col2,col3);
