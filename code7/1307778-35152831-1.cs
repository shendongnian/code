    System.Web.Mail.MailMessage msg = new System.Web.Mail.MailMessage();
            msg.Body = message.Body;
            string smtpServer = "mail.business.it";
            string userName = "username";
            string password = "password";
            int cdoBasic = 1;
            int cdoSendUsingPort = 2;
            if (userName.Length > 0)
            {
                msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", smtpServer);
                msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 25);
                msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", cdoSendUsingPort);
                msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", cdoBasic);
                msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", userName);
                msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", password);
            }
            msg.To = message.Destination;
            msg.From = "me@domain.it";
            msg.Subject = message.Subject;
            msg.BodyFormat = MailFormat.Html;//System.Text.Encoding.UTF8;
            SmtpMail.SmtpServer = smtpServer;
            SmtpMail.Send(msg);
