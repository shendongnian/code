    public static void SendEmail(string subject, string body)
    {
        using (var client = new SmtpClient(yourEmailHost, 25)) //"relay-hosting.secureserver.net"
        using (var message = new MailMessage()
        {
            From = new MailAddress(utilities.FromEmail),
            Subject = subject,
            Body = body
        })
        {
            message.To.Add(address);
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.Credentials = new NetworkCredential("nerwork UserName", "Network Password");
            client.Send(message);
        };
    }
