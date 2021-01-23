    public static void SendEmail(string subject, string body)
    {
        using (var client = new SmtpClient(utilities.EmailHost, 25))
        using (var message = new MailMessage()
        {
            From = new MailAddress(utilities.FromEmail),
            Subject = subject,
            Body = body
        })
        {
            foreach (var address in utilities.DevTeam.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries))
                message.To.Add(address);
            client.Send(message);
        }
    }
