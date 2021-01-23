    class YahooClient : SmtpClient, IMySmtpClient {
    }
    interface IMySmtpClient {
        void Send(MailMessage message);
    }
    class ConsumingMailSender(IMySmtpClient client) {
           // Create message and send
           var message = new MailMessage etc....
   
           client.Send(message);
    }
