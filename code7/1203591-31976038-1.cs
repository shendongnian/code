    public static string CurrentScreenName
    {
        get
        {
            string screenName = (string)HttpContext.Current.Items["CurrentScreenName"];
            if (string.NullOrEmpty(screenName))
            {
                 screenName = ResolveScreenName();
                 HttpContext.Current.Items["CurrentScreenName"] = screenName;
            }
            return screenName;
        }
    }
