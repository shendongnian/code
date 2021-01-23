    public void Send(IdentityMessage message)
    {
       SmtpClient smtp = new SmtpClient();
       // some stuff here to configure SmtpClient
       if (everythingIsOkay)
          smtp.SendEmail(); // throws an exception on error
       else  // something is not right
          throw new ConfigurationException(...);
    }
