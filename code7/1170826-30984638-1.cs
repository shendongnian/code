    var user = db.Users.SingleOrDefault(u => u.UserName == txtUsername.Text);
    if (user == null)
    {
        var user = new User { UserName = txtUsername.Text };
        //UsersContext newUser = new UsersContext(); // Not sure why you need new context, since you are already inside UsersContent
        db.AddUser(user);
        db.SaveChanges(); // only neccessary if User's Id is identity to get newly created Id.
    }
