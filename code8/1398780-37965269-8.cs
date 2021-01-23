    public partial class EcomEntities : DbContext
    {
        public EcomEntities(DbConnection connection)
            : base(connection, true)
        {
        }
        public EcomEntities(string connectionString)
            : base(connectionString)
        {
        }
