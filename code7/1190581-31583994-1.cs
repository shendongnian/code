    public async Task<bool> RetrySendEmail(MailMessage message)
    {
        bool emailSent = false;
        for (int i = 0; i < 3; i++)
        {
             if (emailSent)
                  break;
             else
                  await Task.Delay(5000);
             try
             {
                  Smtphost.Send(message);
                  emailSent = true;
                  break;
             }
             catch (Exception e) { emailSent = false; // log; }
        }
        return emailSent;
    }
