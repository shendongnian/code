        public InviteesDbContext(bool recreate = false)
        {
            if (recreate)
            {
                recreateDatabase(this);
            }
        }
        private static void recreateDatabase(InviteesDbContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            setPermissions(dbContext);
            seed(dbContext); 
        }
