      MailMessage mailObj = new MailMessage("From", "To", "header", "body");
            SmtpClient SMTPServer = new SmtpClient("relayServer");
            mailObj.IsBodyHtml = true;
            mailObj.Attachments.Add(new Attachment(ms, "report.pdf"));
            try
            {
                SMTPServer.Send(mailObj);
            }
            catch (Exception)
            {
                throw;
            }
