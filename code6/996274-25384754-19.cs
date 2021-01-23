        public static System.Data.Common.DbConnectionStringBuilder GetConnectionStringBuilder(string strConnectionString)
        {
            System.Data.Common.DbConnectionStringBuilder dbConString = m_ProviderFactory.CreateConnectionStringBuilder();
            dbConString.ConnectionString = strConnectionString;
            return dbConString;
        } // End Functin GetConnectionStringBuilder
