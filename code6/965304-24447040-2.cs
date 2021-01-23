    string query = "SELECT key, PlayerName, HighScore FROM PlayerPoints ORDER BY HighScore DESC LIMIT 5";
    using(MySqlCommand cmd = new MySqlCommand(query, _connection))
    using(MySqlDataReader reader = cmd.ExecuteReader())
    {
          while (reader.Read())
          {
               MessageBox.Show(string.Format("PlayerName: {0} HighScore: {1}",
                                              reader.GetString(1),
                                              reader.GetString(2)));
          }
    }
