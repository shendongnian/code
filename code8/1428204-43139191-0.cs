    public BooksContext(string connectionString) : this(GetOptions(connectionString))
    {
    }
    private static DbContextOptions GetOptions(string connectionString)
    {
        return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
    }
