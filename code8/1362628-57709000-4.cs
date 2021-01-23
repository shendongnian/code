    public string GetFullDomainName(string friendlyOrQualifiedName)
    {
        string retValue = null;
    
        System.DirectoryServices.ActiveDirectory.DirectoryContext context = null;
        
        if(this.IntegratedSecurity)
        {
            context = new System.DirectoryServices.ActiveDirectory.DirectoryContext(
                System.DirectoryServices.ActiveDirectory.DirectoryContextType.Domain, friendlyOrQualifiedName);
        }
        else
        {
            context = new System.DirectoryServices.ActiveDirectory.DirectoryContext(
                System.DirectoryServices.ActiveDirectory.DirectoryContextType.Domain, friendlyOrQualifiedName, 
                this.Username, this.m_password
            );
        }
        
        using (System.DirectoryServices.ActiveDirectory.Domain domain =
              System.DirectoryServices.ActiveDirectory.Domain.GetDomain(context))
        {
            retValue = domain.Name;
        }
        
        return retValue;
    } // End Function GetFullDomainName 
    
    
    public System.Collections.Generic.List<string> 
        GetDomains() 
    {
        System.Collections.Generic.List<string> domains = 
            new System.Collections.Generic.List<string>();
        
        using (System.DirectoryServices.ActiveDirectory.Forest cf = 
            System.DirectoryServices.ActiveDirectory.Forest.GetCurrentForest())
        {
            
            // Querying the current Forest for the domains within.
            foreach (System.DirectoryServices.ActiveDirectory.Domain d in cf.Domains)
            {
                domains.Add(d.Name);
            } // Next d 
            
        } // End Using cf 
        
        return domains;
    } // End Function GetDomains 
    
    
    /// <summary>
    /// Escapes the LDAP search filter to prevent LDAP injection attacks.
    /// </summary>
    /// <param name="searchFilter">The search filter.</param>
    /// <see cref="https://blogs.oracle.com/shankar/entry/what_is_ldap_injection" />
    /// <see cref="http://msdn.microsoft.com/en-us/library/aa746475.aspx" />
    /// <returns>The escaped search filter.</returns>
    private static string EscapeLdapSearchFilter(string searchFilter)
    {
        string retValue = null;
    
        // http://web.archive.org/web/20160922224553/http://blogs.oracle.com/shankar/entry/what_is_ldap_injection
        // https://docs.microsoft.com/en-us/windows/win32/adsi/search-filter-syntax#special-characters
    
        System.Text.StringBuilder escape = new System.Text.StringBuilder(); 
    
        for (int i = 0; i < searchFilter.Length; ++i)
        {
            char current = searchFilter[i];
            switch (current)
            {
                case '\\':
                    escape.Append(@"\5c");
                    break;
                case '*':
                    escape.Append(@"\2a");
                    break;
                case '(':
                    escape.Append(@"\28");
                    break;
                case ')':
                    escape.Append(@"\29");
                    break;
                case '\u0000':
                    escape.Append(@"\00");
                    break;
                case '/':
                    escape.Append(@"\2f");
                    break;
                default:
                    escape.Append(current);
                    break;
            } // End Switch 
    
        } // Next i 
    
        retValue = escape.ToString();
        escape.Clear();
        escape = null;
    
        return retValue;
    } // End Function EscapeLdapSearchFilter
    
    
    private static string EscapeDN(string name)
    {
        System.Text.StringBuilder escape = new System.Text.StringBuilder();
    
        if ((name.Length > 0) && ((name[0] == ' ') || (name[0] == '#')))
        {
            escape.Append(@"\"); // add the leading backslash if needed
        }
    
        for (int i = 0; i < name.Length; i++)
        {
            char curChar = name[i];
            switch (curChar)
            {
                case '\\':
                    escape.Append(@"\\");
                    break;
                case ',':
                    escape.Append(@"\,");
                    break;
                case '+':
                    escape.Append(@"\+");
                    break;
                case '"':
                    escape.Append(@"\""");
                    break;
                case '<':
                    escape.Append(@"\<");
                    break;
                case '>':
                    escape.Append(@"\>");
                    break;
                case ';':
                    escape.Append(@"\;");
                    break;
                default:
                    escape.Append(curChar);
                    break;
            } // End Switch 
    
        } // Next i 
    
        if ((name.Length > 1) && (name[name.Length-1] == ' '))
        {
            escape.Insert(escape.Length - 1, '\\'); // add the trailing backslash if needed
        } // End if ((name.Length > 1) && (name[name.Length-1] == ' ')) 
    
        return escape.ToString();
    } // End Function EscapeDN 
    
    
    
    
    public string GetUserDomain(string userNameOrEmail)
    {
        System.Collections.Generic.List<string> ls =
            new System.Collections.Generic.List<string>();
    
        userNameOrEmail = EscapeLdapSearchFilter(userNameOrEmail);
    
        foreach (string thisDomain in this.GetDomains())
        {
            // string ldapPath = this.Protocol + "://" + thisDomain;
            
            using (System.DirectoryServices.DirectoryEntry domain = new System.DirectoryServices.DirectoryEntry(thisDomain)) // ldapPath))
            {
                using (System.DirectoryServices.DirectorySearcher searcher = new System.DirectoryServices.DirectorySearcher())
                {
                    searcher.SearchRoot = domain;
                    searcher.SearchScope = System.DirectoryServices.SearchScope.Subtree;
                    searcher.PropertiesToLoad.Add("sAMAccountName");
                    searcher.PropertiesToLoad.Add("mail");
                    searcher.PropertiesToLoad.Add("proxyAddresses");
    
                    // The Filter is very important, so is its query string. The 'objectClass' parameter is mandatory.
                    // Once we specified the 'objectClass', we want to look for the user whose login
                    // login is userName.
                    // searcher.Filter = $"(&(objectClass=user)(sAMAccountName={userName}))";
    
                    // string email = "";
                    // searcher.Filter = $"(&(ObjectClass=user)(mail={email}))";
    
                    // Another example is "(&(objectClass=printer)(|(building=42)(building=43)))"
                    //searcher.Filter = $"(&(objectClass=user)(|(sAMAccountName={userNameOrEmail})(mail={userNameOrEmail})))";
    
                    // case insensitive !
                    searcher.Filter = $"(&(objectClass=user)(|(sAMAccountName={userNameOrEmail})(mail={userNameOrEmail})(proxyAddresses=smtp:{userNameOrEmail})))";
    
                    try
                    {
                        using (System.DirectoryServices.SearchResultCollection results = searcher.FindAll())
                        {
                            // If the user cannot be found, then let's check next domain.
                            if (results == null || results.Count == 0)
                                continue;
                        } // End Using results 
                        
                        // Here, we yield return for we want all of the domain which this userName is authenticated.
                        // yield return domain.Path;
                        
                        // string serv = domain.Options.GetCurrentServerName();
                        // System.Console.WriteLine(serv);
    
                        // ls.Add(domain.Path); 
                        ls.Add(domain.Name); // Full domain name (non-friendly)
                        // Friendly domain name 
                        // if (domain.Properties.Contains("Name")) ls.Add(System.Convert.ToString(domain.Properties["Name"].Value));
    
                        //foreach (System.DirectoryServices.PropertyValueCollection p in domain.Properties)
                        //{
                        //    System.Console.WriteLine(p.PropertyName);
                        //    System.Console.WriteLine(p.Value);
                        //}
                    } // End Try
                    catch (System.Exception)
                    { }
                    
                } // End Using searcher 
                
            } // End Using domain 
            
        } // Next thisDomain
        
        // But hey, you said domain, not domains ;)
        if(ls.Count > 0)
            return ls[0];
        
        return null;
    } // End Function GetUserDomain 
