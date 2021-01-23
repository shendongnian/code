    public class Context : DbContext
        {
            public Context()
                : base("35213027DatatableFromArraylist"){}
    
            public DbSet<DynamicData> DynamicDatas { get; set; }
    
            public DbSet<DynamicData2> DynamicData2s { get; set; }
        }
