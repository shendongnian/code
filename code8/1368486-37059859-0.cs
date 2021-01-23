    public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
    {
        context.DeserializeTicket(context.Token);
        // Now you can access to context.Ticket
        ...
    }
