    if (user != null)
    {
        // Checks whether the user has the Read permission for the CMS.MenuItem page type
        if (UserInfoProvider.IsAuthorizedPerClass(CustomTableClassName, "Read", SiteContext.CurrentSiteName, user))
        {
            // Perform an action according to the result
            return true;
        }
    }
