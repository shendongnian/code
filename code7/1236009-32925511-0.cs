    public static void SendMail(string from, string userName, string subject, string emailBody)
    {
        string htmlBody = string.Format("<html><body><img src=\"cid:Header\" /><br />{0}<br /><img src=\"cid:Footer\" /></body></html>", emailBody);
        AlternateView avHtml = AlternateView.CreateAlternateViewFromString(htmlBody, Encoding.Default, MediaTypeNames.Text.Html);
        // Create a LinkedResource object for each embedded image
        LinkedResource header = new LinkedResource("Header.jpg", MediaTypeNames.Image.Jpeg);
        header.ContentId = "Header";
        LinkedResource footer = new LinkedResource("Footer.jpg", MediaTypeNames.Image.Jpeg);
        header.ContentId = "Footer";
        avHtml.LinkedResources.Add(header);
        avHtml.LinkedResources.Add(footer);
        // Add the alternate views instead of using MailMessage.Body
        var mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(from);
        mailMessage.To.Add(new MailAddress(userName));
        mailMessage.Subject = subject;
        mailMessage.AlternateViews.Add(avHtml);
        // Address and send the message
        var emailClient = new SmtpClient
        {
            EnableSsl = useSsl.ToLower().Contains("true"),
            Credentials = new NetworkCredential(emailLoginUser, emailLoginPassword),
            Host = smtpServerUrl,
            Port = int.Parse(smtpServerPort)
        };
        emailClient.Send(mailMessage);
    }
