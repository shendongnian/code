        using System.Net.Mail;
        
         String BodyMsg = UserName + ", \r\n\nWe have recieved your request to become a user of our site.  Upon review, we will send you verification for site access.\r\n\n" +
                "Thank you, \r\n\nMuda Admin";
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
     
                    mail.From = new MailAddress(ConfigurationManager.AppSettings["AdminEmail"].ToString());
                    mail.To.Add("To@domain.com");
                    mail.Subject = "subject";
                    mail.Body = BodyMsg ;
     
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["AdminEmail"].ToString(), ConfigurationManager.AppSettings["Pwd"].ToString());
                    SmtpServer.EnableSsl = true;
     
                    SmtpServer.Send(mail);
