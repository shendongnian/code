    public static SmtpClient GetSmtpClient()
    {
       var client= new SmtpClient();
       client.Host= _smtpServer;
       client.UseDefaultCredentials = false;
       if (smtpUseDefaultCredential)
       { 
          client.UseDefaultCredentials = true;
       }
       else
       {
          client.UseDefaultCredentials = false;
          client.Credentials = new NetworkCredential(smtpUser, smtpPassword);
       }
                
       if(isPortRequired)
        {
         client.Port= _smtpPort;
        }
        if(isEnableSslRequired)
        {
         client.EnableSsl= true;
        }
        
        return client;
    }
