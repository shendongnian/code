     string[] output = null;
                using (var ctx = new PrincipalContext(ContextType.Domain, domain))
                using (var user = UserPrincipal.FindByIdentity(ctx, username))
                {
                    if (user != null)
                    {
                        output = user.GetGroups()
                            .Select(x => x.SamAccountName)
                            .ToArray();
                    }
                    bool isMember = output.Any(groupName.Contains);
                }
