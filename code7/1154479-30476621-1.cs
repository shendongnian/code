    public void DoLogin() {
       //validation commes here...
    
       //create your session
       Session["User"] = user; //user is your User class object
    
       //create session class for db
       Session session = new Session();
       session.SessionId = ""; //you can generate here a 24 character string
       session.UserId = user.Id;
       session.LoginDate = DateTime.Now;
       db.Add(session); //add session to db
    }
