    public Task SendAsync(IdentityMessage message)
    {
        // Plug in your email service here to send an email.
        try
        {
            #region formatter
            string text = string.Format("Please click on this link to {0}: {1}", message.Subject, message.Body);
            string html = "Please confirm your account by clicking this link: <a href=\"" + message.Body + "\">link</a><br/>";
            html += HttpUtility.HtmlEncode(@"Or click on the copy the following link on the browser:" + message.Body);
            #endregion
    
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("info@emailadress.com");
            msg.To.Add(new MailAddress(message.Destination));
            msg.Subject = message.Subject;
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));
    
            var smtpClient = new SmtpClient();            
            smtpClient.EnableSsl = true;
            smtpClient.SendCompleted += (s, e) => { smtpClient.Dispose(); };
            return smtpClient.SendMailAsync(msg);
        }
        catch (Exception)
        {
            return Task.FromResult(0);
        }
    }
