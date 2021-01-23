    var msg = Messages.NoPassword;
    switch (msg)
    {
        case Messages.NoPassword:
            MessageBox.Show("No password");
            break;
        case Messages.NoUserName:
            MessageBox.Show("No user name");
            break;
        case Messages.NoUserNameOrPassword:
            MessageBox.Show("No user name");
            break;
        case Messages.UserAlreadyExists:
            MessageBox.Show("User already exists");
            break;
    }
