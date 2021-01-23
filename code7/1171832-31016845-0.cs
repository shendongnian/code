     MailMessage emailMsg = new MailMessage();
            emailMsg.To.Add("someonesemail@a.com");
            emailMsg.Subject = "My Subject";
            emailMsg.From = new MailAddress("mysendermeal@myserver.com");
            emailMsg.Body = message;
            emailMsg.BodyEncoding = System.Text.Encoding.ASCII;
            emailMsg.IsBodyHtml = false;
            
            SmtpClient smtp = new SmtpClient("MY-SMTP-SERVER");
            smtp.Send(emailMsg);
