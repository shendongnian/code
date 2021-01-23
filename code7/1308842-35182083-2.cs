    var users= db.Users.Where(i => i.Username.Equals(username)).ToList();
    // do a case sensitive check on users
    var user = users.FirstOrDefault(s=>s.Username.Equals(username));
    if(user!=null)
    {
      // user has the User object
    }
    else
    { 
      // no user matching our CASE SENSITIVE UserName check.
    }
