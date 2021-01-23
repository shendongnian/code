    You can use Owin ... i.e. Microsoft.owin.securoty
    
    I haven't tried this implementation but this is just to give you an idea..
    
    var identity = new ClaimsIdentity(Startup.OAuthBearerOptions.AuthenticationType);
    var currentUtc = new SystemClock().UtcNow;
    ticket.Properties.IssuedUtc = currentUtc;
    ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromMinutes(30));
    DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken); 
        
    return Json(new {
          statusCode = StatusCodes.SUCCESS,
          payload = name,
          username = username.ToLower(),
     accessToken = Startup.OAuthBearerOptions.AccessTokenFormat.Protect(ticket)
        });
