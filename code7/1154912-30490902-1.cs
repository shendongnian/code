    public static class SharedUtilities
    {
        private static SqlConnectionStringBuilder connectionString = null;
        public static SqlConnectionStringBuilder ConnectionString
        {
            get
            {
                if (connectionString == null)
                {
                    connectionString = new SqlConnectionStringBuilder()
                    {
                        DataSource = "dx2v",
                        InitialCatalog = "Q619410",
                        UserID = "tunnelld",
                        Password = "david",
                    };
                 }
                 return connectionString;
             }
        }
    }
