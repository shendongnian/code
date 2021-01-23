    var props = new AuthenticationProperties(new Dictionary<string, string>
            {
                { "userId", "blah,blah" },
                { "role", "admin" }
            });
    var ticket = new AuthenticationTicket(identity, props);
    context.Validated(ticket);
