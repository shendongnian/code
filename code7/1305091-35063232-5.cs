    public Task SendMail(string receiver, string subject, string body)
    {
        this._msg = new MailMessage(UserName, receiver);
        this._msg.From = new MailAddress(UserName, Name);
        this._msg.Subject = subject;
        this._msg.Body = body;
        this._msg.IsBodyHtml = true;
        return this._smtpClient.SendMailAsync(_msg);
    }
