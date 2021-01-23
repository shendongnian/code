    public void SendEmail(PostEmail postEmail)
    {
      MailAddress from = new MailAddress(postEmail.emailFrom, postEmail.emailFromName);
      MailAddress to = new MailAddress(postEmail.emailTo, postEmail.emailToName);
      MailMessage message = new MailMessage(from, to);
      message.Subject = postEmail.subject;
      message.Body = postEmail.body;
      MailAddress bcc = new MailAddress("xxxx@gmail.com");
      message.Bcc.Add(bcc);
      SmtpClient client = new SmtpClient();
      //client.UseDefaultCredentials = false;
      //client.Credentials.GetCredential("smtp.xxxx.com", 587, "server requires authentication");
      Console.WriteLine("Sending an e-mail message to {0} and {1}.", to.DisplayName, message.Bcc.ToString());
      try
      {
        client.Send(message);
      }
      catch (Exception ex)
      {
        Console.WriteLine("Exception caught in CreateBccTestMessage(): {0}",
                    ex.ToString());
      }
    }
