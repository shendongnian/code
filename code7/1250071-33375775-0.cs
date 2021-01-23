     public string getSiteForRotator()
        {
            string CommandText = "SELECT `url`, `desc`, `timer` FROM sites";
            string Connect = "connection_string";
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            myConnection.Open();
            MySqlDataReader MyDataReader;
            MyDataReader = myCommand.ExecuteReader();
    
            string url = "";
             while (MyDataReader.Read())
            {
                url = MyDataReader.GetString(0);
                string desc = MyDataReader.GetString(1);
                int timer = MyDataReader.GetInt32(2);
                url+"," + desc+"," + timer.ToString();
            }
            MyDataReader.Close();
            myConnection.Close();
            return url;
        }
