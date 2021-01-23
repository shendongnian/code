    public bool GetCantChangePassword(string userid)
     {
            bool cantChange = false;
            try
            {
                DirectoryEntry entry = new DirectoryEntry(string.Format("LDAP://{0},{1}", "OU=Standard Users,OU=Domain", "DC=domain,DC=org"));
                entry.AuthenticationType = AuthenticationTypes.Secure | AuthenticationTypes.ServerBind;
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = string.Format("(&(objectClass=user)(objectCategory=person)(sAMAccountName={0}))", userid);
                search.SearchScope = SearchScope.Subtree;
                SearchResult results = search.FindOne();
                if (results != null)
                {
                    try
                    {
                        DirectoryEntry user = results.GetDirectoryEntry();
                        ActiveDirectorySecurity userSecurity = user.ObjectSecurity;
                        SecurityDescriptor sd = (SecurityDescriptor)user.Properties["ntSecurityDescriptor"].Value;
                        AccessControlList oACL = (AccessControlList)sd.DiscretionaryAcl;
                        bool everyoneCantChange = false;
                        bool selfCantChange = false;
                        foreach (ActiveDs.AccessControlEntry ace in oACL)
                        {
                            try
                            {
                                if (ace.ObjectType.ToUpper().Equals("{AB721A53-1E2F-11D0-9819-00AA0040529B}".ToUpper()))
                                {
                                    if (ace.Trustee.Equals("Everyone") && (ace.AceType == (int)ADS_ACETYPE_ENUM.ADS_ACETYPE_ACCESS_DENIED_OBJECT))
                                    {
                                        everyoneCantChange = true;
                                    }
                                    if (ace.Trustee.Equals(@"NT AUTHORITY\SELF") && (ace.AceType == (int)ADS_ACETYPE_ENUM.ADS_ACETYPE_ACCESS_DENIED_OBJECT))
                                    {
                                        selfCantChange = true;
                                    }
                                }
                            }
                            catch (NullReferenceException ex)
                            {
                                //Logger.append(ex.Message);
                            }
                            catch (Exception ex)
                            {
                                Logger.append(ex);
                            }
                        }
                        if (everyoneCantChange || selfCantChange)
                        {
                            cantChange = true;
                        }
                        else
                        {
                            cantChange = false;
                        }
                        user.Close();
                    }
                    catch (Exception ex)
                    {
                        // Log your errors!
                    }
                }
                entry.Close();
            }
            catch (Exception ex)
            {
                // Log your errors!
            }
            return cantChange;
        }
