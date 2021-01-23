    SQLiteCommand command = new SQLiteCommand(sql, connection);
    SqlDataAdapter da = new SqlDataAdapter(commmand);
    SQLiteDataReader reader = command.ExecuteReader();
    while(reader.Read())
    {
    // do nothing if you don't need to manipulate the datas while reading loop
    }
    da.Fill(dataTable);
    dataGridView.ItemsSource= dt.DefaultView;
