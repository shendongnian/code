    public static void SendMail(string To, string Subject, string Body)
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(SmtpUserName, SmtpFrom);
                message.To.Add(new MailAddress(To));
                message.Subject = Subject;
                message.Body = Body;
                message.IsBodyHtml = true;
                message.BodyEncoding = Encoding.UTF8;
                message.SubjectEncoding = Encoding.UTF8;
                
                var client = new SmtpClient(SmtpAddress, SmtpPort)
                {
                    Credentials = new NetworkCredential(SmtpUserName, SmtpPassword),
                };
    
                client.Send(message);            
            }
