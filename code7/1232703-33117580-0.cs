    public String getLoginIDbyUserId(int userID)
        {
            ClientContext siteContext = getClientContextObject();
            User _getUser = siteContext.Web.SiteUsers.GetById(userID);
    
            siteContext.Load(_getUser, u => u.LoginName);
            //siteContext.ExecuteQuery();
            ExecuteContextQuery(ref siteContext);
    
            String loginID = String.Empty;
            String formatedLoginID = String.Empty;
            loginID = _getUser.LoginName;
            if (loginID.Contains('|'))
            {
    
                formatedLoginID = loginID.Substring(loginID.IndexOf('|') + 1);
    
            }
            siteContext.Dispose();
            return formatedLoginID;
        }
