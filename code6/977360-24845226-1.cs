    private int _maxAttempts = 10;
    private async Task TrySendMail(int attemptNumber)   
    {
         var smtpClient = new SmtpClient();
         var mailMsg = new MailMessage("from@test.com", "to@test.com", "Test Subject", "Test Body");
         while (!success && attempts <= maxAttempts)
         {
             try
             {
                 await smtpClient.SendMailAsync(mailMsg)).ConfigureAwait(false);
                 success = true;
            }
            catch
            {
                if (attempts >= maxAttempts)
                {
                    throw;
                }
            }
            attempts++;
        }
  
