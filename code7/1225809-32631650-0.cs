    public void LinkBuilder(string baselink, string sharedkey, string service, string period, string bulletintype,
            string includeresults, string includemap, string username, string password)
        {
            sharedkey = "&" + sharedkey ?? "";
            service = "&" + service ?? "";
            period = "&" + period ?? "";
            bulletintype = "&" + bulletintype ?? "";
            includeresults = "&" + includeresults ?? "";
            includemap = "&" + includemap ?? "";
            username= "&" + username ?? "";
            password = "&" + password ?? "";
    
            string completeLink = sharedkey + service + period + bulletintype + includeresults + includemap + username +
                                  password;
