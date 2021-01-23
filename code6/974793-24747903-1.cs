    private void AddGACode()
    {
        var gaCode = SiteManager.GetSite().GoogleAnalyticsCode;
        if (!String.IsNullOrEmpty(gaCode) && Response.StatusCode == 200)
        {
            gaUniversal.Visible = ConfigurationManager.EnableUniversalGATracking;
            gaGaq.Visible = !ConfigurationManager.EnableUniversalGATracking;
        }
    }
