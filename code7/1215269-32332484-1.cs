    string myName = myComboBox.SelectedItem.Text;
    string Query = "SELECT * FROM [Database] WHERE Name = ?";
    OleDbConnection conn = new OleDbConnection(connection);
    OleDbCommand cmd = new OleDbCommand(Query, conn);
    cmd.Parameters.Add(new OleDbParameter("@name", myName));
    conn.Open();
    OleDbDataReader reader = cmd.ExecuteReader();
    while(reader.Read())
    etc...
