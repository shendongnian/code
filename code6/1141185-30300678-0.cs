     DataTable dt = new DataTable(groupName);
            var _with1 = dt.Columns;
            _with1.Add("AccountID", typeof(string));
            _with1.Add("FirstName", typeof(string));
            _with1.Add("LastName", typeof(string));
            _with1.Add("DisplayName", typeof(string));
            _with1.Add("Email", typeof(string));
            _with1.Add("AccountDisabled", typeof(bool));
            _with1.Add("Groups", typeof(string));
            using (DirectoryEntry rootEntry = new DirectoryEntry(LDAPPath, LDAPUser, LDAPPassword))
            {
                using (DirectorySearcher searcher = new DirectorySearcher(rootEntry))
                {
                searcher.Filter = string.Format("(&(ObjectClass=Group)(CN={0}))", groupName);
                SearchResult result = searcher.FindOne();
                object members = result.GetDirectoryEntry().Invoke("Members", null);
                //<<< Get members
                //<<< loop through members
                foreach (object member in (IEnumerable)members)
                {
                    DirectoryEntry currentMember = new DirectoryEntry(member);
                    //<<< Get directoryentry for user
                    if (currentMember.SchemaClassName.ToLower() == "user")
                    {
                        System.DirectoryServices.PropertyCollection props1 = currentMember.Properties;
                        dt.Rows.Add(props1["sAMAccountName"].Value, props1["givenName"].Value, props1["sn"].Value, props1["displayName"].Value, props1["mail"].Value, Convert.ToBoolean(currentMember.InvokeGet("AccountDisabled")),"");
                    }
                    else if (currentMember.SchemaClassName.ToLower() == "group")
                    {
                        System.DirectoryServices.PropertyCollection props1 = currentMember.Properties;
                        //foreach (var group in result.Properties["member"])
                        //{
                            dt.Rows.Add("","","","","",false,props1["name"].Value);
                        //}
                    }
                }
       }
