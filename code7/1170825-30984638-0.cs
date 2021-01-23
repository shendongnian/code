    if (db.Users.Any(u => u.UserName != txtUsername.Text))
    {
        var newUserObj = new User { UserName = txtUsername.Text };
        UsersContext newUser = new UsersContext();
        newUser.AddUser(newUserObj);
    }
