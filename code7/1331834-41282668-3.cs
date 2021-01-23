        public class MyContext : DbContext
        {
            public virtual DbSet<MyTable> MyTable { get; set; }
            public MyContext(DbConnection connection) :
                   base(new DbContextOptionsBuilder().UseNpgsql(connection)
                                                     .ReplaceService<ISqlGenerationHelper, SqlGenerationHelper>()
                                                     .Options) 
            { }
        }
