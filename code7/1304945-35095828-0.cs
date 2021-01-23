    Web oWebsite = clientContext.Web;
    clientContext.Load(oWebsite, website => website.Webs);
    clientContext.ExecuteQuery();
    foreach (Web orWebsite in oWebsite.Webs)
    {
        AddUserToDMSite(useremail, securityGroupName, orWebSite)
    }
