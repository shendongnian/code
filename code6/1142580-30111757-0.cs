    Email newUser = new Email();
    Regex rxMail = new Regex(@"(?i)^(?=.{0,256}$)[a-z0-9_\+-]+(?:\.[a-z0-9_\+-]+)*@[a-z0-9-]+(?:\.[a-z0-9-]+)*\.[a-z]{2,4}$");
    foreach (string email in user.Emails)
    {
       if (rxMail.IsMatch(email))
       {
           newUser.Address = email;
       }
    }
