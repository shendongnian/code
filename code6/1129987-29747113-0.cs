      public DateTime GetLastUpdatedDate()
            {
                string connectionString="";//your connection string to connect to Ms Sql database 
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandText = @" SELECT top 1 last_user_update
                                            FROM sys.dm_db_index_usage_stats
                                            WHERE database_id = DB_ID( 'YourDatabase')
                                            AND OBJECT_ID=OBJECT_ID('TableNameThatGetsUpdatedOrInserted')";
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 60;
                        return (DateTime)cmd.ExecuteScalar();
                    }
                }
            }
