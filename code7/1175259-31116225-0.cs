     public static SqlDatabase SqlDB(string connectionString)
        {
            if (sqlDB == null || sqlDB.ConnectionString != connectionString)
            {
                sqlDB = CreateConnection(connectionString);
            }
            return sqlDB;
        }
