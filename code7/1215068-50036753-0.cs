    // this is caleld after AuthenticationTokenProvider.Receive
    public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
    {
        base.GrantRefreshToken(context);
        if (UserLocked(context.Ticket.Identity))
        {
            context.Rejected();
            context.SetError("invalid_grant", "User is locked", "usr-lockout");
        }
    }
