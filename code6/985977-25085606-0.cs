    var newUser = db.UserDetails.FirstOrDefault(newuser => newuser.UserMail == user.UserMail && newuser.AccId == accID);
    if (newUser == null)
    {    
        var user = new User();
        var account = db.Accounts.FirstOrDefault(acc => acc === "some account");
        if(account != null)
        {
            //Depending on your entity, you may need to check if Accounts is null here.
            user.Accounts.add(account);
        }
        db.Users.Add(user);
        
        try
        {
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }
        catch
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
