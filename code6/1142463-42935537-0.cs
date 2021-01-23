    public void ConfigureAuth(IAppBuilder app)
    {
         HttpListener listener = (HttpListener)app.Properties["System.Net.HttpListener"];
         listener.AuthenticationSchemes = AuthenticationSchemes.IntegratedWindowsAuthentication;
    }
