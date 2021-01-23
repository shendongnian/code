     public static string DomainControllerName { get; private set; }
     public static string ComputerName { get; private set; }
     public static string DomainName { get; private set; }
     public static string DomainPath
     {
                get
                {
                    bool bFirst = true;
                    StringBuilder sbReturn = new StringBuilder(200);
                    string[] strlstDc = DomainName.Split('.');
                    foreach (string strDc in strlstDc)
                    {
                        if (bFirst)
                        {
                            sbReturn.Append("DC=");
                            bFirst = false;
                        }
                        else
                            sbReturn.Append(",DC=");
    
                        sbReturn.Append(strDc);
                    }
                    return sbReturn.ToString();
                }
     }
            public static string RootPath
            {
                get
                {
                    return string.Format("LDAP://{0}/{1}", DomainName, DomainPath);
                }
            }
    Domain domain = null;
    DomainController domainController = null;
    try
    {
    	domain = Domain.GetCurrentDomain();
            DomainName = domain.Name;
            domainController = domain.PdcRoleOwner;
            DomainControllerName = domainController.Name.Split('.')[0];
            ComputerName = Environment.MachineName;
    }
    finally
    {
    if (domain != null)
           domain.Dispose();
    if (domainController != null)
           domainController.Dispose();
    }
    try
    {
    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
        {
                    DirectoryEntry root = new DirectoryEntry(RootPath, txtUserName.Text.Trim(), txtPassword.Text);
                    DirectorySearcher search = new DirectorySearcher(root);
                search.SearchScope = SearchScope.Subtree;
                search.Filter = "(sAMAccountName=" + txtUserName.Text.Trim() + ")";
                SearchResultCollection results = search.FindAll();
                UserPrincipal userP = UserPrincipal.FindByIdentity(ctx, txtUserName.Text.Trim());
                if (userP != null && results != null)
                {
                    //Get the user's groups
                    var groups = userP.GetAuthorizationGroups();
                    if (groups.Count(x => x.Name == ConfigurationManager.AppSettings["UserGroup"].ToString()) > 0)
                    {
                        //Successful login code here
                    }
                    else
                    {
                        //"Access Denied !";
                    }
                }
                else
                {
                    //"User Name or Password is incorrect. Try again !"
                }
            }
        }
        catch
        {
            //"User Name or Password is incorrect. Try again !"
        }
