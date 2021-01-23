      PrincipalContext ctx = new PrincipalContext(
                                            ContextType.Domain,
                                            ConfigurationManager.AppSettings["ADDomainName"],
                                            ConfigurationManager.AppSettings["ADContainer"],
                                            ConfigurationManager.AppSettings["ADUserName"],
                                            ConfigurationManager.AppSettings["ADPassword"]);
                    UserPrincipal users = UserPrincipal.FindByIdentity(ctx, user.UserName);
                    DirectoryEntry entry = users.GetUnderlyingObject() as DirectoryEntry;
                    PropertyCollection props = entry.Properties;
                 
                    if (entry.Properties["countryCode"].Value != null)
                    {
                        user.CountryCode = entry.Properties["countryCode"].Value.ToString();
                    }
