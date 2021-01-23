    TResult WithSftpClient<TResult>(Func<TResult, SftpClient> operation)
    {
      TResult result = default(TResult);
      // Note that one may need to re-create "client" here 
      // as it is disposed on every WithSftpClient call -
      // make sure it is re-initialized in some way.
      using(sftpClient)
      {
        sftpClient.Connect();
        try
        {
            result = operation(sftpClient);
        }
        catch(Exception ex)
        {
           // log/retrhow exception as appropriate
        }
        // hack if given class does not close connection on Dispose
        // for properly designed IDisposable class similar line not needed
        sftpClient.Disconnect(); 
      }
      return result;
    }
