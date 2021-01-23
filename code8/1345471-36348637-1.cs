    public class Model : DbContext
    {
        public Model()
            : base(ConnectionString())
        {
        }
        
        public virtual DbSet<MyEntity> MyEntities { get; set; }
        private static string ConnectionString()
        {
            // logic here
            return "Data Source=(local);Initial Catalog=xx;Integrated Security=False;User ID=sa;Password=xx;MultipleActiveResultSets=True;App=EntityFramework";
        }
    }
