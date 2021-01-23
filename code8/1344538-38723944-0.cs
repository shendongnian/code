    DataTable dt = new DataTable();
    SQLiteConnection cnn = new SQLiteConnection(dbConnection);
    cnn.Open();
    SQLiteCommand mycommand = new SQLiteCommand(cnn);
    mycommand.CommandText = sql;
    SQLiteDataAdapter adapter = new SQLiteDataAdapter(mycommand);
    adapter.Fill(dt);
    cnn.Close();
