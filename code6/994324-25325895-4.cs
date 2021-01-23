    public static void CSVToMySQL2()
    {
        string ConnectionString = "server=192.168.1xxx";
        StringBuilder sCommand = new StringBuilder("INSERT INTO User (FirstName, LastName) VALUES ");           
        using (MySqlConnection mConnection = new MySqlConnection(ConnectionString))
        {
            List<string> Rows = new List<string>();
            for (int i = 0; i < 100000; i++)
            {
                Rows.Add(string.Format("('{0}','{1}')", "test", "test"));
            }
            sCommand.Append(string.Join(",", Rows));
            sCommand.Append(";");
            mConnection.Open();
            using (MySqlCommand myCmd = new MySqlCommand(sCommand.ToString(), mConnection))
            {
                myCmd.CommandType = CommandType.Text;
                myCmd.ExecuteNonQuery();
            }
        }
    }
