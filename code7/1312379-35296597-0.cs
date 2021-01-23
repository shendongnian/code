    public override Task ValidateIdentity(OAuthValidateIdentityContext context)
    {            
        var result=  base.ValidateIdentity(context);
        if (context.IsValidated )
        {
            var ticket = context.Ticket;
            if (ticket != null && ticket.Identity.IsAuthenticated && ticket.Properties.ExpiresUtc > DateTime.UtcNow)
            {
                if (1==2)//TODO: put your server side condition here
                {
                    context.SetError("HaHa!");
                }
            }
        }
        return result;
    }
