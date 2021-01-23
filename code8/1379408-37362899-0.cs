    MailMessage message = new MailMessage(Sender, Receivers, Subj, Body);
    SmtpClient client = new SmtpClient(ServerName);
    try {
      client.Send(message);
    } catch (Exception ex) {
      Console.WriteLine("Cannot send message.");
    }
