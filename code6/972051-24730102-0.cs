    container.RegisterPerWebRequest(() =>
    {
        if (HttpContext.Current != null && HttpContext.Current.Items["owin.Environment"] == null && container.IsVerifying())
        {
            return new OwinContext().Authentication;
        }
        return HttpContext.Current.GetOwinContext().Authentication;
       
    });
