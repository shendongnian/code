    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            Database.Connection.ConnectionString = System.IO.File.ReadAllText("Path to your text File");
        }
    }
