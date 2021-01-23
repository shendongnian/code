    public async Task SendAsync(IdentityMessage message)
    {
      ...
      using (var smtpClient = new SmtpClient())
      {
        smtpClient.EnableSsl = true;
        smtpClient.SendCompleted += (s, e) => { smtpClient.Dispose(); };
        await smtpClient.SendMailAsync(msg);
      }
    }
