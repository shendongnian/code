    class UserManager
    {
        public bool IsValid(string username, string password)
        {
             using(var db=new MyDbContext()) // use your DbConext
             {
                 // if your users set name is Users
                 return db.Users.Any(u=>u.Username==username 
                     && u.Password==password); 
             }
        }
    }
