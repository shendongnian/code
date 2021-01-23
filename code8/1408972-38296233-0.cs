     using (var db = new DB())
     {
       var result = db.users
       .Where(u => u.username == txtUsername.Text && u.password == txtPassword.Text)
       .Select( a => new User
       {
         id = a.user_id,
         name = a.username,
         roleID = a.role_id
       })
      .ToList(); //error here
    }
