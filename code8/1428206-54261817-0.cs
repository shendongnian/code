    using System;
    using System.Globalization;
    using System.Linq;
    using Microsoft.Extensions.Configuration;
    
    namespace CallCenter.Repositories
    {
        public class TestRepository : ITestRepository 
        {
            private readonly InsuranceContext _context;
            public TestRepository InsuranceContext context)
            {
                _context = context;
            }
    
            public void Add(string passedInStringWhichTellsWhatDatabaseToUse)
            {
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
    
                var configuration = builder.Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                
    
                    var agencyContext = new AgencyContext(connectionString.Replace("Database=replacethisstring", "Database=" + passedInStringWhichTellsWhatDatabaseToUse));
    
                    var company = agencyContext.Companys.FirstOrDefault(x => x.ColumnNameInDb == "xyz");
                    if (company != null)
                    {
                        companyId = company.CompanyId.ToString();
                    }
    
    ... your other code here which could include the using the passed in _context from the injected code (or you could not have any context passed in and just use dynamic context
                }
    
            }
        }
    }
    //The AgencyContext class would look like this:
    
    using Microsoft.EntityFrameworkCore;
    
    namespace CallCenter.Entities
    {
        public class AgencyContext : DbContext
        {
            public AgencyContext(string connectionString) : base(GetOptions(connectionString))
            {
                
            }
    
            private static DbContextOptions GetOptions(string connectionString)
            {
                return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
            }
            public DbSet<Companys> Companys { get; set; }
        }
    }
    //The startup.c IServiceProvider module has this:
    
            public IServiceProvider ConfigureServices(IServiceCollection services)
            {
                services.AddOptions();
               
                services.AddDbContext<InsuranceContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.UseRowNumberForPaging()));
                services.AddScoped<ITestRepository , TestRepository >();
    ....
    }
