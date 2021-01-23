    private int _maxAttempts = 10;
    private async Task TrySendMail(int attemptNumber)   
    {
         var smtpClient = new SmtpClient();
         while (!success && attempts <= maxAttempts)
         {
             try
             {
                 await smtpClient.SendMailAsync(new MailMessage("from@test.com", "to@test.com", "Test Subject", "Test Body")).ConfigureAwait(false);
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
  
