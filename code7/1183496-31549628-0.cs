        public static string checkUserName(string userName)
        {
            if (!userName.Contains("@"))
            {
                return userName.Trim() + "@domain.local".Trim();
            }
            return userName.Trim();
        }
 	try
            {
                string connectionPrefix = "LDAP://" + ldapPath;// ldapPart;// ldapPath
                var adminUserName = GetAdminUserName(orgservice, unsecureConfig, secureConfig);
                var adminPassword = GetAdminPassword(orgservice, unsecureConfig, secureConfig);
                if (CheckIfUserExists(getSAMNameFromUserName(userName), trace) == true)
                {
                    trace.Trace("About to handle success. A User already exists: " + getSAMNameFromUserName(userName));
                    trace.HandleSuccess();
                    throw new Exception("User " + getSAMNameFromUserName(userName) + " already exists.");
                }
                DirectoryEntry dirEntry = new DirectoryEntry(connectionPrefix, adminUserName, adminPassword, AuthenticationTypes.Secure);
                DirectoryEntry newUser;
                string cn = firstName.Trim() + " " + lastName.Trim();
                newUser = dirEntry.Children.Add("CN=" + cn, "user"); //display name - This is the "Display" name that shows up on the AD list. 
                newUser.Properties["displayName"].Value = cn;
                newUser.Properties["samAccountName"].Value = getSAMNameFromUserName(userName).Trim();
                newUser.Properties["userPrincipalName"].Value = checkUserName(userName).Trim();
                newUser.Properties["givenName"].Value = firstName.Trim(); //Firstname
                newUser.Properties["sn"].Value = lastName.Trim(); //Lastname? -Surname
                //newUser.Properties["LockOutTime"].Value = 0; //unlock account. Set this to 0 to unlock the account.
                newUser.CommitChanges();
                oGUID = newUser.Guid.ToString();
                //Must be handled after the previous stuff. Unsure why.
                newUser.Invoke("SetPassword", new object[] { userPassword });
                newUser.CommitChanges();
                //For some reason, can't be handled before the password is set?
                newUser.Properties["userAccountControl"].Value = 0x10200; //0x0200
                newUser.CommitChanges();
                //http://stackoverflow.com/questions/20710535/is-there-a-way-to-set-a-new-users-domain-suffix-through-the-userprincipal-class
                newUser.Close();
                dirEntry.Close();
                //newUser.Close(); //Close user first, then dirEntry because of the heirarchy call?
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException E)
            {
                System.DirectoryServices.DirectoryServicesCOMException newE = new System.DirectoryServices.DirectoryServicesCOMException(E.Message);
                //DoSomethingwith --> E.Message.ToString();
                throw newE;
            }
