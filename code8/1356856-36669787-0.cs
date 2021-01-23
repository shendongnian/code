    app.UseFacebookAuthentication(options => {
        options.Events = new OAuthEvents {
            OnCreatingTicket = context => {
                var surname = context.User.Value<string>("last_name");
                context.Identity.AddClaim(new Claim(ClaimTypes.Surname, surname));
    
                return Task.FromResult(0);
            }
        };
    });
