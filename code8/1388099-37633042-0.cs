        private void OpenConnection()
        {
            lock (syncLock)
            {
                if (_connection == null || _connection.State == ConnectionState.Closed || _connection.State == ConnectionState.Broken)
                {
                    _connection = new SqliteConnection("Data Source=" + DbPath);
                    _connection.SetPassword(DbKey);
                    _connection.Open();
                }
            }
        }
        private int ExecuteNonQuery(string query)
        {
            lock (syncLock)
            {
                OpenConnection();
                int rowcount = 0;
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = query;
                    try
                    {
                        rowcount = command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Logger.Error("ExecuteNonQuery", e.Message + ". Query:" + query);
                    }
                    command.Dispose();
                }
                return rowcount;
            }
        }
