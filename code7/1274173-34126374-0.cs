    public static class EntityFrameworkExtensions 
    {
        public static Account GetAccountById(this DbSet<Account> dbSet, int accountId) 
        {
            return dbSet.Find(accountId);
            // or dbSet.FirstOrDefault(x => x.Id == accountId) for non-primary key columns
        }
    }
