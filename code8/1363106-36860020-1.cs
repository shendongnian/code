    ModelDB sql = new ModelDB();
    var users = from users in sql.Users where Username = Main_T_Username.Text select users;
    if(users.Count() == 0)
        MessageBox.Show("WrongPass or Username!");
    else if(users.Count() > 0 && users[0].Password.SequenceEqual(password))
        MessageBox.Show("username and Password = Correct");
    else
        MessageBox.Show("Password = Wrong");
        
