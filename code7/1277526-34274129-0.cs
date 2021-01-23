    protected void Application_BeginRequest()
    {
        var originalUri = HttpContext.Current.Request.Url;
        var finalUri = new UriBuilder(originalUri);
        finalUri.Path = RemoveAccents(
            originalUri.GetComponents(UriComponents.Path, UriFormat.SafeUnescaped)
        );
        // Check if the URL has changed
        if (!originalUri.Equals(finalUri.Uri))
        {
            HttpContext.Current.Response.Redirect(finalUri.Uri.ToString(), true);
            HttpContext.Current.Response.End();
        }
    }
