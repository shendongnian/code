    public async Task CreateAsync(AuthenticationTokenCreateContext context)
    {
        //...
        context.Ticket.Properties.AllowRefresh = true;
        token.ProtectedTicket = context.SerializeTicket();
        //...
    }
