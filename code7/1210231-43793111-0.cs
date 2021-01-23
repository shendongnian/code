    public class EntityFrameworkConfiguration : DbConfiguration
    {
        public EntityFrameworkConfiguration()
        {
            this.SetModelCacheKey(ctx => new EntityModelCacheKey((ctx.GetType().FullName + ctx.Database.Connection.ConnectionString).GetHashCode()));
        }
    }
    [DbConfigurationType(typeof(EntityFrameworkConfiguration))]
    public class MyContext : DbContext
    {
        public MyContext(DbConnection existingConnection, bool contextOwnsConnection) 
            : base(existingConnection, contextOwnsConnection)
        { }
        public DbSet<Stuff> Stuff { get; set; }
    }
    using(var conn = new SqlConnection(asqlserverConnectionString))
                using (var db = new MyContext(conn, true))
                {
                    var value = await db.Stuff.Where(s => s.xxx.Equals(primaryKey)).Select(s => new { s.BinaryContent } ).SingleOrDefaultAsync();
                }
