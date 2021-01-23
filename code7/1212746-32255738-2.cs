    MailMessage message = new MailMessage();          
    message.From = new MailAddress("example@gmail.com");
    message.To.Add(new MailAddress("example@gmail.com"));
    message.Subject = "Subject";
    message.Body = "Body";
    
    try
    {
      using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
      {
          smtpClient.UseDefaultCredentials = false;
          smtpClient.EnableSsl = true;
    
           ServicePointManager.ServerCertificateValidationCallback =
                            delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                            {
                                return true;
                            };
    
          smtpClient.Credentials = new NetworkCredential("email@gmail.com", "password");
          smtpClient.Send(emailMessage);
      }
    }
    catch (Exception e)
    {
          emailMessage = null;
    }
