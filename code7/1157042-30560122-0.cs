    private void FillStatisticsList()
    {
        try
        {
            const string statsQuery = "SELECT * FROM cached_queries WHERE is_statistics IS TRUE;";
            var connection = new MySqlConnection(DatabaseModel.ConnectionString);
            connection.Open();
            var cmd = new MySqlCommand(statsQuery, connection);
            cmd.ExecuteNonQuery();
            var reader = cmd.ExecuteReader();
            cmd.CommandType = CommandType.Text;
            StatisticsQueries = new ObservableCollection<Query>();
            while (reader.Read())
            {
                StatisticsQueries.Add(new Query
                {
                    Id = reader["id"].ToString(),
                    Autoschool = reader["autoschool"].ToString(),
                    IsStatistics = reader["is_statistics"].ToString(),
                    Name = reader["query_name"].ToString(),
                    Text = reader["query_text"].ToString()
                });
            }
            connection.Close();
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }
