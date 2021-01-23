    public interface IDbConnectionFactory {
        /// <summary>
        ///  Creates a connection based on the given database name or connection string.
        IDbConnection CreateConnection(string nameOrConnectionString);
    }
