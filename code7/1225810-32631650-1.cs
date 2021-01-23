    public void LinkBuilder(string baselink, string sharedkey, string service, string period, string bulletintype,
            string includeresults, string includemap, string username, string password)
        {
            sharedkey = checkValue(sharedkey);
            service = checkValue(service );
            period = checkValue(period );
            bulletintype = checkValue(bulletintype );
            includeresults = checkValue(includeresults );
            includemap = checkValue(includemap );
            username= checkValue(username );
            password = checkValue(password );
    
            string completeLink = sharedkey + service + period + bulletintype + includeresults + includemap + username +
                                  password;
    }
    private String checkValue(String str)
    {
        return str != null ? "&" + str : "";
    }
