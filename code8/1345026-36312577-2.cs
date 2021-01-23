    string conn_str = "Data Source=dbServer;Initial Catalog=testDB;Integrated Security=True";
    string sql_str = “select * from table1”;
     
    SqlDataAdapter data_adapter = new SqlDataAdapter(sql_str, conn_str);
    SqlCommandBuilder cmd_builder = new SqlCommandBuilder(data_adapter);
     
    // Populate a new data table and bind it to the BindingSource.
    DataTable table = new DataTable();
    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
    // This line populates our new table with the data from our sql query
    data_adapter.Fill(table);
    db_binding_source.DataSource = table;
     
    // Resize the DataGridView columns to fit the newly loaded content.
    data_grid_view.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
    // you can make it grid readonly.
    data_grid_view.ReadOnly = true; 
    // finally bind the data to the grid
    data_grid_view.DataSource = db_binding_source;
