    public bool IsLoggedIn(User user) {
       Session session = db.GetSession(user.Id); //Get session of the user
    
       if(session != null)
       {
          return true;
       } else {
          return false;
       }
    }
