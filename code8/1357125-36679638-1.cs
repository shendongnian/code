    string connetionString = null;
    OleDbConnection connection;
    OleDbDataAdapter oledbAdapter = new OleDbDataAdapter();
    string sql = null;
    connetionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0; Data Source=../boosterbase.mdb";
    connection = new OleDbConnection(connetionString);
    sql = "insert into " + drpCardSet.Text + " values('" + drpCardSet.Text + "-EN" + txtCardSetNo.Text + "','" + txtCardName.Text + "','" + drpCardRarity.Text + "', '" + drpCardCatagory.Text + "', '" + updCardInStock.Text + "')";
    try
    {
        connection.Open();
        oledbAdapter.InsertCommand = new OleDbCommand(sql, connection);
        oledbAdapter.InsertCommand.ExecuteNonQuery();
        MessageBox.Show("Row(s) Inserted !! ");
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.ToString());
    }
