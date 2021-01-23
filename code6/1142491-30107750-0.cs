    public string UICulture 
    {
        set 
        {
            CultureInfo newUICulture = null;
 
            if(StringUtil.EqualsIgnoreCase(value, HttpApplication.AutoCulture))
            {
                CultureInfo browserCulture = CultureFromUserLanguages(false);
                if(browserCulture != null) 
                {
                    newUICulture = browserCulture;
                }
            }
            else if(StringUtil.StringStartsWithIgnoreCase(value, HttpApplication.AutoCulture)) 
            {
                CultureInfo browserCulture = CultureFromUserLanguages(false);
                if(browserCulture != null) 
                {
                    newUICulture = browserCulture;
                }
                else
                {
                    try 
                    {
                        newUICulture = HttpServerUtility.CreateReadOnlyCultureInfo(value.Substring(5));
                    }
                    catch {}
                }
            }
            else
            {
                newUICulture = HttpServerUtility.CreateReadOnlyCultureInfo(value);
            }
 
            if (newUICulture != null) 
            {
                Thread.CurrentThread.CurrentUICulture = newUICulture;
                _dynamicUICulture = newUICulture;
            }
        }
        get { return Thread.CurrentThread.CurrentUICulture.DisplayName; }
    }
