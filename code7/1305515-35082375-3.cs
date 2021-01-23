    public class Database : IDatabase
    {
        public DataSet ProvideCultureMappings(Guid userId, Culture culture)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database database = factory.CreateDefault();
            using (DbConnection dbConnection = database.CreateConnection())
            {
                if (dbConnection.State == ConnectionState.Closed)
                    dbConnection.Open();
                DbCommand dbCommand = database.GetStoredProcCommand("usp_UpdatePersonCulture");
                database.DiscoverParameters(dbCommand);
                dbCommand.Parameters["@userId"].Value = userId;
                dbCommand.Parameters["@cultureId"].Value = culture.Id;
                DataSet dataSet = database.ExecuteDataSet(dbCommand);
                return dataSet;
            }
        }
        private DataSet ExecuteDataSet(DbCommand dbCommand)
        {
            throw new NotImplementedException();
        }
        private void DiscoverParameters(DbCommand dbCommand)
        {
            throw new NotImplementedException();
        }
        private DbCommand GetStoredProcCommand(string uspUpdatepersonculture)
        {
            throw new NotImplementedException();
        }
        private DbConnection CreateConnection()
        {
            throw new NotImplementedException();
        }
    }
