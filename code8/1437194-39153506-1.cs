    namespace EF {
        public class GeneralContext: DbContext {
    
            public DbSet<SalesRepresentative> SalesRepresentatives { get; set; }
        }
    }
