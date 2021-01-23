    public interface IStatsRepository
    {
                IEnumerable<FederalDistrict> FederalDistricts();
    }
        
    class StatsRepository : IStatsRepository
    {
       private readonly DbContextOptionsBuilder<EFCoreTestContext>
                    optionsBuilder = new DbContextOptionsBuilder<EFCoreTestContext>();
       private readonly IConfigurationRoot configurationRoot;
        
       public StatsRepository()
       {
           IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
           configurationRoot = configurationBuilder.Build();
       }
        
       public IEnumerable<FederalDistrict> FederalDistricts()
       {
            var conn = configurationRoot.GetConnectionString("EFCoreTestContext");
            optionsBuilder.UseSqlServer(conn);
        
            using (var ctx = new EFCoreTestContext(optionsBuilder.Options))
            { 
                return ctx.FederalDistricts.Include(x => x.FederalSubjects).ToList();
            }
        }
    }
