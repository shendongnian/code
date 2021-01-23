    public partial class MyEntities
    {
        /// <summary>
        /// This constructor allows us to pass connection strings at runtime
        /// </summary>
        /// <param name="connectionString">Entity Framework connection string</param>
        public MyEntities(string connectionString) : base(connectionString)
        {
        }
    }
