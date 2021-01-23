    app.UseOwin(
        owin =>
            {
                // Arbitrary IAppBuilder registrations can be placed in this block
                // For example, this extension can be provided by
                // NWebsec.Owin or Thinktecture.IdentityServer3
                owin.UseHsts();
            } );
           
    // ASP.NET 5 components, like MVC 6, will still process the request
    // (assuming the request was not handled by earlier middleware)
    app.UseMvc();
