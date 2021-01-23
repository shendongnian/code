@{
            if (HttpContext.Current.Request.Url.AbsoluteUri.IndexOf("SiteA") != -1)
            {
                <link href="~/Content/bootstrap.css" rel="stylesheet"  type="text/css"/>
            }
            else if (HttpContext.Current.Request.Url.AbsoluteUri.IndexOf("SiteB") != -1)
            {
                <link href="~/Content/Bootstrap-theme.css" rel="stylesheet"  type="text/css"/>
            }
            else if (HttpContext.Current.Request.Url.AbsoluteUri.IndexOf("SiteC") != -1)
            {
                <link href="~/Content/Bootstrap-theme2.css" rel="stylesheet"  type="text/css"/>
            }
        }
