            List<string> idList = new List<string>();
            idList.Add("someid");
            idList.Add("someid");
            idList.Add("someid");
            List<Data> d = new List<Data>();
            foreach (string id in idList)
            {
                user.Name = id;
                PrincipalSearcher pS = new PrincipalSearcher();
                pS.QueryFilter = user;
                PrincipalSearchResult<Principal> results = pS.FindAll();
                Principal pc = results.ToList()[0];
                DirectoryEntry de = (DirectoryEntry)pc.GetUnderlyingObject();
                var userData = new Data();
                userData.ID = de.Properties["samAccountName"].Value.ToString();
                userData.name = de.Properties["givenName"].Value.ToString();
                userData.lastName = de.Properties["sn"].Value.ToString();
                userData.mail = de.Properties["mail"].Value.ToString();
                userData.organization = de.Properties["extensionAttribute2"].Value.ToString();
                d.Add(userData);
            }
