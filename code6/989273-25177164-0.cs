            static List<string> GetUsersInForest()
            {
                var winIdentity = System.Web.HttpContext.Current.User.Identity as System.Security.Principal.WindowsIdentity;
                if (winIdentity == null) throw new InvalidOperationException();
                using (var ictx = winIdentity.Impersonate())
                {
                    List<string> users = new List<string>();
                    using (var f = System.DirectoryServices.ActiveDirectory.Forest.GetCurrentForest())
                    {
                        foreach (Domain d in f.Domains)
                        {
                            using (d)
                            {
                                foreach (string user in GetUsersInDomain(d.Name))
                                {
                                    int idx = users.BinarySearch(user);
                                    if (idx < 0) users.Insert(~idx, user);
                                }
                            }
                        }
                    }
    
                    return users;
                }
            }
