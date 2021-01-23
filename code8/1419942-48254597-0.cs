    .UseStartup<Startup>()
    .UseHttpSys(options =>
    {
        options.Authentication.Schemes =
            AuthenticationSchemes.NTLM | AuthenticationSchemes.Negotiate;
        options.Authentication.AllowAnonymous = false;
    })
    .Build();
