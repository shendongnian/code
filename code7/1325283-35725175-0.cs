    static void SendEmail()
    {
        using (SmtpClient smtpClient = new SmtpClient())
        using (MailMessage message = new MailMessage())
        using (Attachment attachment = new Attachment(Application.StartupPath + @"\log.txt"))
        {
            NetworkCredential basicCredential =
                new NetworkCredential("", "");
                
            MailAddress fromAddress = new MailAddress("");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Port = "";
            smtpClient.Host = "";
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = basicCredential;
            smtpClient.EnableSsl = true;
            message.From = fromAddress;
            message.Subject = "";
            //Set IsBodyHtml to true means you can send HTML email.
            message.IsBodyHtml = true;
            message.Body = "";
            message.To.Add("");
            message.Attachments.Add(attachment);
            smtpClient.Send(message);
        }
    }
