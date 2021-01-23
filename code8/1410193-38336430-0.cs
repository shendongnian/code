    while (!User.IsLoggedIn)
    {
        string user;
        string pass;
        if (Login.Show(out user, out pass) == DialogResult.OK)
        {
            User.Authenticate(user, pass);
        }
        else
        {
            MessageBox("Unable to log in!");
            break;
        }
    }
    if (User.IsLoggedIn)
    {
        Application.Run(new MainForm());
    }
