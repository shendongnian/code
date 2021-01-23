             MailMessage message = !string.IsNullOrEmpty(fromEmail) ? new MailMessage(fromEmail, To) : new MailMessage(From, To);
            if (BCC.Length > 0)
            {
                message.Bcc.Add(BCC);
            }
            message.IsBodyHtml = IsBodyHtml;
            message.Subject = Subject;
            message.Body = Body;
            // Email Attachment
            if (!string.IsNullOrEmpty(attachedPath))
            {
                Attachment attach = new Attachment(attachedPath);
                // Attach the created email attachment 
                message.Attachments.Add(attach);
            }
            //create mail client and send email
            SmtpClient emailClient = new SmtpClient();
            emailClient.Host = SMTPServer;
            emailClient.Port = SMTPPort;
            emailClient.Credentials = new NetworkCredential(SMTPUserName, SMTPPassword);
            emailClient.EnableSsl = EnableSSLForSMTP;
            emailClient.Send(message);
            //Here you can dispose it after sending the mail.
            message.Dispose();
