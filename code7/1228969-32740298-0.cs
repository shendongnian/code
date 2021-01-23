     try
     {
         var mailClient = new SmtpClient {Credentials = credentials};
     }
     catch(Exception)
     {
         // Evil: you swallow your exception, mailClient is null
         // The program continues and god drowns a kitten.
     }
     if (mailClient != null)
     {
         mailClient.SendAsync(mailMessage, usertoken);
         return Task.FromResult(0);
     }
