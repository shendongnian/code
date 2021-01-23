    public class FunClass
    {
        private DbContextOptions<MyDbContext> _dbContextOptions;
    
        public FunClass(DbContextOptions<MyDbContext> dbContextOptions) {
            _dbContextOptions = dbContextOptions;
        }       
        public List<string> GetUsers()
        {
			using (var db = new MyDbContext(_dbContextOptions))
			{
				return db.Users.Select(c=>c.UserName).ToList();
            }
        }
    }
