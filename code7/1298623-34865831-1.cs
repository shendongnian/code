                  using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, dc.IPAddress, path, ContextOptions.Negotiate, ManagementUsername, ManagementPassword))
                    {
                        try
                        {
                            using (UserPrincipal up = new UserPrincipal(pc, username, password, true))
                            {
                                up.GivenName = firstName; up.Surname = lastName; up.DisplayName = firstName + " " + lastName; up.UserPrincipalName = username + "@" + Domain; up.Save();
                            }
                        }
                        catch (PasswordException) { return null; }
                    }
