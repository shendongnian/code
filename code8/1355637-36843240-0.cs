    static void Perform_Deletions(List<UserAccountObject> User_List, string directory)
        {
            string ldapServer = null;
            string parentOU = null;
            string userCN = null;
            string ldapDirectory = null;
            string userName = null;
            string passWord = null;
            // REGEX value to only return OU path portion of User DN
            string dnSuffixRegex = @"ou.*";
            Regex myDNRegex = new Regex(dnSuffixRegex, RegexOptions.IgnoreCase);
            // REGEX to only Return the CN portion of User DN
            string cnRegex = @"^([^,]+)";
            Regex myCNRegex = new Regex(cnRegex, RegexOptions.IgnoreCase);
            switch (directory)
            {
                case "AD1":
                    {
                        ldapDirectory = "LDAP://ad1.contosoe.com/";
                        userName = "Admin";
                        passWord = @"P@$$W0rd1";
                        break;
                    }
                case "AD2":
                    {
                        ldapDirectory = "LDAP://ad2.contosof.com/";
                        userName = "Admin";
                        passWord = @"P@$$W0rd1";
                        break;
                    }
                case "EDIR1":
                    {
                        ldapDirectory = "LDAP://edirectory1.contosoc.com/";
                        userName = @"cn=Admin,o=Root";
                        passWord = @"P@$$W0rd1";
                        break;
                    }
                case "AD3":
                    {
                        ldapDirectory = "LDAP://ad3.contosod.com/";
                        userName = "Admin";
                        passWord = @"P@$$W0rd1";
                        break;
                    }
                case "EDIR2":
                    {
                        ldapDirectory = "LDAP://edirectory2.contosob.com/";
                        userName = @"cn=Admin,o=Root";
                        passWord = @"P@$$W0rd1";
                        break;
                    }
                case "EDIR3":
                    {
                        ldapDirectory = "LDAP://edirectory3.contosoa.com/";
                        userName = @"cn=Admin,o=Root";
                        passWord = @"P@$$W0rd1";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            foreach (UserAccountObject user in User_List)
            {
                foreach (Match cnMatch in myCNRegex.Matches(user.Distinguished_Name))
                {
                    userCN = cnMatch.ToString();
                }
                foreach (Match dnMatch in myDNRegex.Matches(user.Distinguished_Name))
                {
                    parentOU = dnMatch.ToString();
                }
                ldapServer = ldapDirectory + parentOU;
                try
                {
                    DirectoryEntry myLdapconnection = new DirectoryEntry(ldapServer, userName, passWord, AuthenticationTypes.ServerBind);
                    DirectoryEntry userToDelete = myLdapconnection.Children.Find(userCN);
                    myLdapconnection.RefreshCache();
                    myLdapconnection.Children.Remove(userToDelete);
                    myLdapconnection.CommitChanges();
                    myLdapconnection.Close();
                    myLdapconnection.Dispose();
                    user.Deletion_Status = "SUCCEEDED";
                }
                catch (Exception e)
                {
                    user.Deletion_Status = "FAILED";
                    Console.WriteLine("Exception Caught:\n\n{0}", e.ToString());
                }
            }
        }
