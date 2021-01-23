    AuthenticationSchemes DetermineAuthenticationScheme( HttpListenerRequest request )
    {
        if ( request == null )
        {
            throw new ArgumentNullException( "request" );
        }
    
        if ( request.RawUrl.IndexOf( "v1/foo", StringComparison.OrdinalIgnoreCase ) >= 0 )
        {
            return AuthenticationSchemes.IntegratedWindowsAuthentication;
        }
    
        return AuthenticationSchemes.Anonymous;
    }
