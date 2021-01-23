    public static IEnumerable<T> ReadData<T>(string queryString)
        {
            using (var connection = new SQLiteConnection(ConnectionBuilder.ConnectionString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = queryString;
                    using (var reader = cmd.ExecuteReader())
                        if (reader.HasRows)
                            while (reader.Read())
                                yield return Mapper.Map<DataRow, T>(reader);
                }
            }
        }
