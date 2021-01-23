    if (string.IsNullOrWhiteSpace(username))
    {
        MessageBox.Show("Username is empty, please enter a username!");
        return;
    }
    if (string.IsNullOrWhiteSpace(password))
    {
        MessageBox.Show("Password is empty, please enter a password!");
        return;
    }
    bool isvalid = auth.ValidateCredentials(username, password);
    {
        if (isvalid)
        {
            MessageBox.Show("Authenticated!");
        }
        else
        {
            MessageBox.Show("Not Authenticated!");
        }
    }
