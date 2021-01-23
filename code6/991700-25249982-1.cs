    public async Task SendSmtpMailAsync()
    {
        SmtpClient smtpClient = new SmtpClient();
        MailMessage mailMessage = new MailMessage("FromAddress", "ToAddress", "Subject", "Body");
        await smtpClient.SendMailAsync(mailMessage);
        // Possibly do more stuff here.
    }
