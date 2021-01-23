    [WebMethod]
    public static List<EmailDetails> GetEmails()
    {
        if(HttpContext.Current.Application["sortedEmailAddresses"]==null) {
    
            List<EmailDetails> emailAddresses = new List<EmailDetails>();
    
            //queries AD to pull all users
            var search = new DirectorySearcher();
            search.Filter = "(&(objectClass=user)(mail=*)(displayName=*))";
            search.PageSize = 1000;
    
            using (var results = search.FindAll())
            {
                foreach (SearchResult result in results)
                {
                    emailAddresses.Add(new EmailDetails
                    {
                        EmailAddress = result.Properties["mail"][0].ToString(),
                        EmailDisplayName = result.Properties["displayName"][0].ToString()
                    });
                }
            }
    
            //sort email address list alphabetically and return sorted list
            List<EmailDetails> sortedEmailAddresses = emailAddresses.OrderBy(o => o.EmailDisplayName).ToList();
            HttpContext.Current.Application["sortedEmailAddresses"] = sortedEmailAddresses;
        }
        return HttpContext.Current.Application["sortedEmailAddresses"] as List<EmailDetails>;
    }
