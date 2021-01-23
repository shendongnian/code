    private void SendMailToSendGrid(Mail mail)
    {
        SendGridMessage mailMsg = new SendGridMessage();
        mailMsg.From = new MailAddress(mail.Sender);
        SendGrid.SmtpApi.Header header = new SendGrid.SmtpApi.Header();
        header.SetTo(mail.Receivers);
        mailMsg.AddTo(mail.Receivers);
        foreach (KeyValuePair<String, List<String>> tag in mail.Tags)
            header.AddSubstitution(tag.Key, tag.Value);
        foreach (String s in mail.BCC)
            mailMsg.AddBcc(s);
        foreach (String s in mail.CC)
            mailMsg.AddCc(s);
        mailMsg.Subject = mail.Subject;
        mailMsg.Html = mail.Content;
        foreach (String s in mail.Attachments)
            mailMsg.AddAttachment(s);
        mailMsg.Headers.Add("x-smtpapi", header.JsonString());
        NetworkCredential credential = new NetworkCredential(sLogin, sPassword);
        var transportWeb = new Web(credential);
        
        try
        {
            transportWeb.DeliverAsync(mailMsg).Wait();
        }
        catch (InvalidApiRequestException ex)
        {
            var errDetail = new StringBuilder();
 
            errDetail.Append("ResponseStatusCode: " + ex.ResponseStatusCode + ". ");
 
            for (int i = 0; i < ex.Errors.Count(); i++)
            {
                errDetail.Append(" -- Error # " + i.ToString() + " : " + ex.Errors[i]);
            }
 
            throw new ApplicationException(errDetail.ToString(), ex);
        }
    }
