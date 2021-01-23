        bool IsDatabaseInUse(string databaseName)
        {
            using (SqlConnection sqlConnection = new SqlConnection("... your connection string ..."))
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.Connection = sqlConnection;
                sqlCmd.CommandText =
                    @"select count(*)
                    from sys.dm_tran_locks
                    where resource_database_id = db_id(@database_name);";
                sqlCmd.Parameters.Add(new SqlParameter("@database_name", SqlDbType.NVarChar, 128)
                {
                    Value = databaseName
                });
                sqlConnection.Open();
                int sessionCount = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (sessionCount > 0)
                    return true;
                else
                    return false;
            }
        }
