                    SmtpClient smtpClient = new SmtpClient();
                    MailMessage message = new MailMessage();
                    smtpClient.Host = "host name";
                    smtpClient.Port = 25;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential("user name", "password");
                    smtpClient.EnableSsl = false;
                    message.IsBodyHtml = true;
    
                    message.Priority = MailPriority.Normal;
                    message.From = new MailAddress("from email address");
                    string file = @"your file complete path";
                    Attachment data = new Attachment(file);
                    message.Attachments.Add(data);
                    data.Name = "newfilename";
                    message.To.Add("testemailaddress");
                    message.Subject = "test email";
                    message.Body = "test email";
                    smtpClient.Send(message);
    
