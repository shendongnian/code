    public async Task<User> GetADUserAsync(PrincipalContextParameter param)
        {
            try
            {
                if (UseLDAPForIdentityServer3)
                {
                    using (var pc = new PrincipalContext(ContextType.Domain, param.ADDomain, param.ADServerContainer, param.ADServerUser, param.ADServerUserPwd))
                    {
                        UserPrincipal userPrincipal = await UserPrincipal.FindByIdentity(pc, param.UserNameToValidate);
                        if (userPrincipal != null)
                        {
                            bool isvalid = await pc.ValidateCredentials(userPrincipal.DistinguishedName, param.UserPasswordToValidate, ContextOptions.SimpleBind);
                            if (isvalid)
                            {
                                User user = new User { ad_guid = userPrincipal.Guid.ToString(), Username = param.UserNameToValidate, Password = param.UserPasswordToValidate };
                                return user;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return null;
        }
