    class UserManager
    {
        public bool IsValid(string username, string password)
        {
             using(var db=new MyDbContext()) // use your DbConext
             {
                 // for the sake of simplicity I use plain text passwords
                 // in real world hashing and salting techniques must be implemented   
                 return db.Users.Any(u=>u.Username==username 
                     && u.Password==password); 
             }
        }
    }
