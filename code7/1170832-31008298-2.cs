    public static bool AddToGroup(string computerName, string groupName)
            {
                using (
                    var context = new PrincipalContext(
                        ContextType.Domain,
                        "Domain",
                        "ServiceAccountLogonName",
                        "ServiceAccountPassword"))
                {
                    using (var group = GroupPrincipal.FindByIdentity(context, groupName))
                    {
                        using (var computer = ComputerPrincipal.FindByIdentity(context, computerName))
                        {
                            if (group == null || computer == null)
                            {
                                return false;
                            }
                            group.Members.Add(computer);
                            group.Save();
                            return true;
                        }
                    }
                }
            }
