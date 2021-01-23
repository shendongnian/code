    var gaCode = SiteManager.GetSite().GoogleAnalyticsCode;
    if (!String.IsNullOrEmpty(gaCode) && Response.StatusCode == 200) {
        gaGaq.Text = string.Format(gaGaq.Text, gaCode );
        gaUniveral.Text = string.Format(gaUniveral.Text, gaCode );
        gaUniveral.Visible = ConfigurationManager.EnableUniversalGATracking;
        gaGaq.Visible = !gaUniveral.Visible;
    }
