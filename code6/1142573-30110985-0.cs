    Email newUser = new Email();
    Regex regex = new Regex("^[a-zA-Z0-9_\\+-]+(\\.[a-zA-Z0-9_\\+-]+)*@[a-zA-Z0-9-]+(\\.[a-zA-Z0-9-]+)*\\.[a-zA-Z]{2,4}$");   
    foreach (string email in user.Emails)
    {
        if (regex.IsMatch(email) ) {
           newUser.Address = email;
        }
    }
