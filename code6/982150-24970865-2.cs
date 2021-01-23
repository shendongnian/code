        Task.Factory.StartNew(() =>
        { 
           var smtp = new SmtpClient();
           try
           {
              var toEmails = mailMessage.To.ToList();
              var bccEmails = mailMessage.Bcc.ToList();
    
              foreach (var email in toEmails)
              {
                 mailMessage.To.Clear();
                 mailMessage.To.Add(email);
                 mailMessage.Bcc.Clear();
    
                 smtp.Send(mailMessage);
              }
           }
           catch (Exception ex)
           {
             Logger.Error(ex);
           }
        }).Wait();
