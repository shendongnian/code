    public partial class CompanyFormsContext : DbContext
    {
        public CompanyFormsContext()
            : base(CreateOptions(null))
        {
        }
        public CompanyFormsContext(string connName)
            : base(CreateOptions(connName))
        {
        }
        DbContextOptions<BloggingContext> CreateOptions(string connName)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>();
            optionsBuilder.UseSqlite("Filename=./blog.db");
            if (connName == null)
            {
                optionsBuilder.UseSqlServer(@"Server=.\;Integrated Security=True;Database=CompanyFormsContext");
            }
            else
            {
                optionsBuilder.UseSqlServer(@"Server=.\;Integrated Security=True;Database=" + connName);
            }
            return optionsBuilder.Options;
        }
    
