    class SendMail
    {
        public void sendMail(MailMessage dailyMail)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.google.com";
            client.Send(dailyMail);
        }
    }
