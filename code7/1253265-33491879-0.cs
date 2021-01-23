    public class UserService
    {
        MyContext _db;
        public UserService(MyContext db)
        {
            _db = db;
        }
        public void GetUserById(string id)
        {
            _db.Users.First(x => x.Id = id);
        } 
    }
