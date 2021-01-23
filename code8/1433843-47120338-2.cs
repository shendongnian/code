    public Task SendEmailAsync(string email, string subject, string message)
    {
        //Added .Wait()
        return Send(email, subject, message).Wait();
    }
