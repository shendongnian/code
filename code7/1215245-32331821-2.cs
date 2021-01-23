    string[] email = { "emailone@gmail.com", "emailtwo@gmail.com", "emailthree@gmail.com" };
    using (MailMessage mm = new MailMessage())
    {
        try
        {
            mm.From = new MailAddress("myaddress@gmail.com");
            foreach (string address in email)
            {
                mm.To.Add(address);
            }
            mm.Subject = "sub;
            // Other Properties Here
        }
       catch (Exception ex)
       {
           Response.Write("Could not send the e-mail - error: " + ex.Message);
       }
    }
