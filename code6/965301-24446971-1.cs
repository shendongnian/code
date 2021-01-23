    public void ShowFirstFiveHighScore()
    {
        string query = "SELECT 'key', PlayerName, HighScore FROM PlayerPoints ORDER BY HighScore DESC LIMIT 5";
        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               MessageBox.Show(string.Format("{0}-{1}"),reader.GetString(1),
                                          reader.GetString(2));
            }
            cmd.ExecuteNonQuery();
            this.CloseConnection();
        }
    }
