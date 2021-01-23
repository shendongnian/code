    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    
    namespace EFCoreSample.Model
    {
        public class SampleContextFactory : IDesignTimeDbContextFactory<SampleContext>
        {
            public SampleContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<SampleContext>();
                optionsBuilder.UseSqlServer(@"Server=.\;Database=db;Trusted_Connection=True;", opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
    
                return new SampleContext(optionsBuilder.Options);
            }
        }
    }
