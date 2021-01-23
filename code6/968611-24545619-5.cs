    // Method used to retrieve data from DB
    string GetFormattedText()
    {
        string myConnection = "datasource=localhost;port=3306;username=root;password=";            
        using (MySqlConnection myConn = new MySqlConnection(myConnection))
        {
            myConn.Open();
            using (MySqlCommand command = myConn.CreateCommand())
            {
                command.CommandText = "Select * FROM database_name.table1";
                using (MySqlDataReader myReader = command.ExecuteReader())
                {
                   try
                   {
                       StringBuilder sb = new StringBuilder();
                       while (myReader.Read())
                       {
                           if (sb.Length > 0)
                               sb.Append(Environment.NewLine);
                            for (int i = 0; i < myReader.FieldCount; i++)
                               sb.AppendFormat("{0}    ", myReader[i]);                               
                        }
                        return sb.ToString();
                   }
                   catch (Exception ex)
                   {
                        MessageBox.Show(ex.Message);
                   }
                }
            }
        }
        return string.Empty;
    }
