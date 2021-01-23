    public User GetUser(int userId)
    {
       User singleUser = null;
       
       using(var db = new MyContext())
       {
          var users = from user in db.Users.Include(u => u.UserGoals.Select(ug => ug.Goal))
                    where user.UserId == userId
                    select user;
    
          singleUser = users.FirstOrDefault();
       }
    
       return singleUser;
    }
