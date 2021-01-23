    ...
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        IssuerSigningKey = _configuration.GetSymmetricSecurityKey(),
        ValidAudience = _configuration.GetValidAudience(),
        ValidIssuer = _configuration.GetValidIssuer()
    };
