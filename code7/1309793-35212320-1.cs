    using (MailClient client = CreateMailClient())
    {
        await client.SendMailAsync(email.Message);
        return true;
    }
    private SmtpClient CreateMailClient()
    {
        MailClient client = new MailClient();
        // Configure client.
        return client;
    }
