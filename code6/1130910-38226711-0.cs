    var listener = (HttpListener)app.Properties["System.Net.HttpListener"];
    
    listener.AuthenticationSchemeSelectorDelegate = request =>
    {
        // Options requests should always be anonymous otherwise preflight cors requests
        // will fail in Firefox.
        if (request.HttpMethod == "OPTIONS")
        {
            return AuthenticationSchemes.Anonymous;
        }
    
        // here we add additional whitelisted paths
        var pathsWithoutAuthentication = KnownPaths.AnonymousWhiteList.Concat(KnownPaths.Assets);
    
        return pathsWithoutAuthentication.Any(a => request.RawUrl.ToLower().StartsWith(a))
            ? AuthenticationSchemes.Anonymous
            : AuthenticationSchemes.IntegratedWindowsAuthentication;
    };
