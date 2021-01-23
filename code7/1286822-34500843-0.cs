    using (OleDbConnection conn = new OleDbConnection(
        @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\foo.accdb"))
    {
        conn.Open();
        OleDbCommand command = new OleDbCommand(
            @"INSERT INTO TotalPlayerName ([Player Name]) VALUES (@p1)", conn);
        command.Parameters.Add(new OleDbParameter("@p1", OleDbType.VarChar));
        for (int i = 0; i < numberOfPlayers; i++)
        {
            command.Parameters[0].Value = textbox[i].Text;
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // do something
            }
        }
        conn.Close();
    }
