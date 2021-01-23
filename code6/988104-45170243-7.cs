    /// <summary>
    /// Expose the method that takes a passed in connection string
    /// </summary>
    public partial class SomeEntities: DbContext
    {
        public SomeEntities(string connectionString)
            : base(connectionString)
        {
        }
    }
