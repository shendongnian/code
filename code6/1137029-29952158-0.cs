    static Task sendMail(IdentityMessage message)
    {
        string text = string.Format("Please confirm your account by pasting this link on your browser\'s address bar:\n\n{0}", message.Body);
        string html = "Please confirm your account by clicking <a href=\"" + message.Body + "\">this link</a><br/>";
        MailMessage msg = new MailMessage();
        msg.From = new MailAddress("id@gmail.com");
        msg.To.Add(new MailAddress(message.Destination));
        msg.Subject = message.Subject;
        msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
        msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32(587));
        System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("id@gmail.com", "gmailpassword");
        smtpClient.Credentials = credentials;
        smtpClient.EnableSsl = true;
        return smtpClient.SendMailAsync(msg);
    }
