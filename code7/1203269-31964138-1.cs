    SQLiteCommand command = new SQLiteCommand(connection);
    command.CommandText = "SELECT * FROM users_details"
    
    SQLiteDataAdapter da = new SQLiteDataAdapter(command);
    DataSet ds = new DataSet();
    da.Fill(ds);
    DataTable dt = ds.Tables[0];
    this.dataGrid.ItemsSource = dt.AsDataView();
