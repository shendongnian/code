    public static void SendEmail(string subject, string body)
    {
        using (var client = new SmtpClient(Your EmailHost, 25))
        using (var message = new MailMessage()
        {
            From = new MailAddress(utilities.FromEmail),
            Subject = subject,
            Body = body
        })
        {
            message.To.Add(address);
            client.Send(message);
        };
    }
