    public void Send(IdentityMessage message)
    {
       SmtpClient smtp = new SmtpClient();
       // some stuff here to configure SmtpClient
       if (everythingIsOkay)
          smtp.SendEmail();
       else  // something is not right
          ???
    }
