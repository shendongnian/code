    public class FunClass
    {
        private GMBaseContext db;
        public FunClass(IServiceProvider services, DbContextOptions dbOptions) 
        {
            db = new GMBaseContext(services, dbOptions);
        }
        public List<string> GetUsers()
        {
             var lst = db.Users.Select(c=>c.UserName).ToList();
            return lst;
        }
    }
