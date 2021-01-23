    var user = Context.Users.SingleOrDefault(u => u.Username == "userName" && u.Password == "password");
    
    if(user != null)
    {
       MessageBox.Show("Success loging");
    }
    else
    {
        MessageBox.Show("Failed");
    }
