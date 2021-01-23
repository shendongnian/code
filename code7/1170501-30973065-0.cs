    string strName = System.Security.Principal.WindowsIdentity.GetCurrent().Name; // "MW\\dalem"
            string domainName = strName.Split('\\')[0];
            using(var pc = new PrincipalContext(ContextType.Domain, domainName))
                {
                    using (var user = new UserPrincipal(pc, Admin-Username, Admin-Pass, true))
                    {
                        fullname = fname + " " + lname;
                        user.SamAccountName = username;
                        user.SetPassword(password);
                        user.GivenName = fname;
                        user.Surname = lname;
                        user.DisplayName = fullname;
                        userPrincipal.Add(user);
                    }
                pc.SaveChanges();
                }
