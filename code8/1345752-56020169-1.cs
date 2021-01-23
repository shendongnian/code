    public class FunClass
    {
        private IConfiguration _configuration;
    
        public FunClass(IConfiguration configuration) {
            _configuration = configuration;
        }
        
		private MyDbContext GetContext() {
			var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            var db = new MyDbContext(optionsBuilder.Options);
            return db;
		}
        public List<string> GetUsers()
        {
			using (var db = GetContext())
			{
				return db.Users.Select(c=>c.UserName).ToList();
            }
        }
    }
