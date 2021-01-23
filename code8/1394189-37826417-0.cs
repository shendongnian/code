      public String getToken(string userName)
        {
         using (var domainContext = new PrincipalContext(ContextType.Domain, "domain"))
            {
              using (var foundUser = UserPrincipal.FindByIdentity(domainContext, IdentityType.SamAccountName, userName))
                {
                    Console.WriteLine("User Principale name" + UserPrincipal.FindByIdentity(domainContext, IdentityType.SamAccountName, userName).UserPrincipalName);
                    string spn = UserPrincipal.FindByIdentity(domainContext, IdentityType.SamAccountName, userName).UserPrincipalName;
                    KerberosSecurityTokenProvider k1 = new KerberosSecurityTokenProvider(spn, System.Security.Principal.TokenImpersonationLevel.Impersonation, new System.Net.NetworkCredential(userName, "password", "domain"));
                    KerberosRequestorSecurityToken T1 = k1.GetToken(TimeSpan.FromMinutes(1)) as KerberosRequestorSecurityToken;
                    string sret = Convert.ToBase64String(T1.GetRequest());
                    Console.WriteLine("=====sret========" + sret);
                    return sret;
                }
            }
           
        }
