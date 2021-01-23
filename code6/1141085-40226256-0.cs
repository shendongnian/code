    public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
    {
        context.DeserializeTicket(context.Token);
        if (context.Ticket != null)
        {            
            context.SetTicket(context.Ticket);            
        }            
    }
