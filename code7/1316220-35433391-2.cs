    public async Task SendAsync(IdentityMessage message)
    {
       SmtpClient smtp = new SmtpClient();
       // some stuff here to configure SmtpClient
       if (everythingIsOkay)
          await smtp.SendEmailAsync(); // throws an exception on error
       else  // something is not right
          throw new ConfigurationException(...);
    }
