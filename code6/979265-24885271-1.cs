        private PriorityDBContext dbContext = null;
        public UnitOfWork()
        {
            PriorityDBContext dbContext = new PriorityDBContext();
        }
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext as PriorityDBContext;
        }
