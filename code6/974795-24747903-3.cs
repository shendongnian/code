    private void AddGACode()
    {
        var gaCode = SiteManager.GetSite().GoogleAnalyticsCode;
        if (!String.IsNullOrEmpty(gaCode) && Response.StatusCode == 200)
        {
            if(ConfigurationManager.EnableUniversalGATracking)
            {   
                //Set gaCode
                gaUniversal.Text = string.Fomat(gaUniveral.Text, gaCode);
            }
            else
            {  
                //Set gaCode             
                gaGaq.Text = string.Format(ga.Text, gaCode);
            }
              
            gaUniversal.Visible = ConfigurationManager.EnableUniversalGATracking;
            gaGaq.Visible = !ConfigurationManager.EnableUniversalGATracking;
        }
        else
        {
           //Hide Both literals if no gaCode
           gaUniversal.Visible = gaGaq.Visible = false;
        }
    }
