    public async Task<User> GetAsyncADUser(PrincipalContextParameter param)
    {        
        if (UseLDAPForIdentityServer3)
        {
            return await Task.Run() =>
            {
                using (var pc = new PrincipalContext(ContextType.Domain, param.ADDomain, param.ADServerContainer, param.ADServerUser, param.ADServerUserPwd))
                {
                    UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(pc, param.UserNameToValidate);
                    if (userPrincipal != null)
                    {
                        bool isvalid = pc.ValidateCredentials(userPrincipal.DistinguishedName, param.UserPasswordToValidate, ContextOptions.SimpleBind);
                        if (isvalid)
                        {
                            User user = new User { ad_guid = userPrincipal.Guid.ToString(), Username = param.UserNameToValidate, Password = param.UserPasswordToValidate };
                            return user;
                        }
                    }
                }
            }
        }
        return null;
    }
