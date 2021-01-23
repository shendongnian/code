    private static readonly List<string> extensionsToValidate = new List<string>(new string[] { ".aspx", "" });
    private void AuthenticateRequest(Object sender, EventArgs e)
    {
        //Ignore specified extensions from redirection
        string CurrentExt = Path.GetExtension(HttpContext.Current.Request.Url.LocalPath);
        if (extensionsToValidate.Contains(CurrentExt))
        {
            //do all security check work here
        }
        else return;
    }
