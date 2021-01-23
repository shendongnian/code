    config.Filters.Add(new AuthFilter());
    // I also have this in my Web API config. Not sure if I had to add this manually or the default project had these lines already...
    config.SuppressDefaultHostAuthentication();
    config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
           
