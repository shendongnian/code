        public bool IsAuthenticated(string username, string pwd)
        {
            string strLDAPServerAndPort = "ldap.domain.com:389";
            string strLDAPContainer = "CN=Users,DC=domain,DC=com";
           
            string strLDAPPath = "LDAP://" + strLDAPServerAndPort + "/" + strLDAPContainer;
            DirectoryEntry objDirEntry = new DirectoryEntry(strLDAPPath, username, pwd);
            try
            {
                //Bind to the native AdsObject to force authentication.
                object obj = objDirEntry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(objDirEntry);
                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();
                if (null == result)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error authenticating user. " + ex.Message);
            }
            return true;
        }
