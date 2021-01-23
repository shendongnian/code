    public static Task SendEmailAsync(MessageContent messageContent, string emailBody)
    {
       SmtpClient smtpClientNoSend = new SmtpClient();
       return smtpClientNoSend.SendMailAsync(mailMessage);
    }
    
    public async Task<ActionResult> Register()
    {
       await SendEmailAsync();
    }
    
    private Task SendEmailAsync()
    {
       return SMTPEmail.SendEmailAsync(msg, output.ToString());
    }
