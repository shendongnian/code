    public MyContext(string connectionString) : base(GetOptions(connectionString))
    {
    }
    private static DbContextOptions GetOptions(string connectionString)
    {
        return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
    }
