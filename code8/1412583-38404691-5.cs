    public Task<bool> SendRegisterEmail(string subject, string message, string to)
    {
        var email = new Email();
        // ... 
        return Send(email);
    }
