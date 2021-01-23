    public partial class EcomEntities : DbContext
    {
        public EcomEntities(DbConnection connection)
            : base(connection, true)
        {
        }
