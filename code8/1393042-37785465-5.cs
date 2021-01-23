    public async Task SendEmail(MailMessage message)
    {
        using(var smtp = new SmtpClient())
        {
            smtp.SendAsync(message);
            await Observable.FromEventPattern<>(x => smtp.SendCompleted +=x, x => smtp.SendCompleted -=x)
                      .ToTask()
        }
    }
