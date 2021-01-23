    public User GetUser(int userId)
    {
       using(db=new MyContext)
       {
          var users=from user in db.Users.Include(u=>u.UserGoals.Select(ug=>ug.Goal))
                    where user.UserId=userId
                    select user;
    
          var singleUser=users.FirstOrDefault();
       }
    
       return singleUser;
    }
