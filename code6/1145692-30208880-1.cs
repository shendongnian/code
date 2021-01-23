    for (int i = 0; i < recipients.Count; i++)
    {
        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
        message.IsBodyHtml = true;
        message.To.Add(recipients[i]);
        message.Subject = subject;
        message.From = from;
        message.Body = body;
        System.Net.Mail.SmtpClient smtp = smtpClient;
        smtp.Send(message);
    }
