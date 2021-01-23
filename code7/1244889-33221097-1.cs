    // If we're self-hosting, enable integrated authentication (if we're using
    // IIS, this will be done at the IIS configuration level).
    var listener = app.ServerFeatures.Get<WebListener>();
    if (listener != null)
    {
        listener.AuthenticationManager.AuthenticationSchemes = 
            AuthenticationSchemes.NTLM;
    }
