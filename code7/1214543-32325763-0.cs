    public static class DbContextFactory
    {
        public static IDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
