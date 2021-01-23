    public class UserRepository : IUserRepository<User>
    {
        private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        public List<User> GetAll()
        {
            return this._db.Query<User>("SELECT * FROM Users").ToList();
        }
    }
