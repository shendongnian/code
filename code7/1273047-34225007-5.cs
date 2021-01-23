    private MailMessage MailMessageFactory(EmailDTO emailDto)
    {
        var text = emailDto.Body;
        var html = emailDto.Body;
        var mailMessage = new MailMessage();
        foreach (var recipient in emailDto.To)
        {
            mailMessage.To.Add(new MailAddress(recipient));
        }
        mailMessage.From = new MailAddress(emailDto.From);
        mailMessage.Subject = emailDto.Subject;
        mailMessage.Body = emailDto.Body;
        mailMessage.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
        mailMessage.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));
        mailMessage.IsBodyHtml = true;
        return mailMessage;
    }
