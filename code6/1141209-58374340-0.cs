    public string GetManagerId(string id)
        {
            string managerNetId = "Not_Found";
            try
            {
                using (DirectorySearcher searcher = new DirectorySearcher(Context.LdapConnection))
                {
                    //We search known user Id 
                    searcher.Filter = "(sAMAccountName=" + id + ")";
                    //We search Manager Property
                    searcher.PropertiesToLoad.Add("manager");
                    
                    SearchResult result = searcher.FindOne();
                    string DistingedName = result.Properties["manager"][0].ToString();
                    // We create domain context                    
                    PrincipalContext PrContext = new PrincipalContext(ContextType.Domain, "YourDomain.com", "OU=Users,OU=****,OU=****,OU=****,DC=*****,DC=*****");
                    //We  define a "query-by-example" principal - here, we search for a UserPrincipal 
                    UserPrincipal qbeUser = new UserPrincipal(PrContext);
                    // We define parameter for search operation
                    string mngt = DistingedName.Trim();
                    qbeUser.Surname = mngt.Substring(mngt.IndexOf("=") + 1, mngt.IndexOf(",") - 4).ToLower();
                    string fnm = mngt.Insert(1, "\\,");
                    qbeUser.GivenName = fnm.Substring(mngt.IndexOf(",") + 4, mngt.IndexOf(",") - 5).ToLower() + "*";          
                    // create your principal searcher passing in the QBE principal    
                    PrincipalSearcher srch = new PrincipalSearcher(qbeUser);
                    // find all matches
                    foreach (var found in srch.FindAll())
                    {
                        // We check if is realy user Manager
                        if (found.DistinguishedName == DistingedName)
                        {
                            managerNetId = found.SamAccountName;
                        }
                    }
                    return managerNetId;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        } 
   
     public string GetManagerMail(string managerNetId)
        {
            try
            {
                using (DirectorySearcher searcher = new DirectorySearcher(Context.LdapConnection))
                {
                    searcher.Filter = "(sAMAccountName=" + id + ")";
                    searcher.PropertiesToLoad.Add("mail");
                    SearchResult result = searcher.FindOne();
                    return result.Properties["mail"][0].ToString();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
   
