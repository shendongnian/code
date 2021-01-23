    public MailRepository(string mailServer, int port, bool ssl, string login, string password)
    {
      try {
        if (ssl) {
    	  Client.ConnectSsl(mailServer, port);
        }
        else {
    	  Client.Connect(mailServer, port);
        }
      Client.Login(login, password);
      }
      catch(Exception ex)
      {
         //Check the exception details here
      }
    }
