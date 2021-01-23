    public class UserService
    {
        MyContext _db = new MyContext();
        public UserService()
        {
        }
        public void GetUserById(string id)
        {
            _db.Users.First(x => x.Id = id);
        } 
    }
