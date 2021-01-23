        private static DateTime? getPwdExpiration(string usuario)
        {
            DirectoryEntry searchGroup = new DirectoryEntry("LDAP://ldapUrl");
            DateTime? dt=null;
            foreach (DirectoryEntry user in searchGroup.Children)
            {
                if (user.InvokeGet("userPrincipalName") != null)
                {
                    string username = user.InvokeGet("userPrincipalName").ToString();
                    username = username.Substring(0, username.IndexOf('@'));
                    if (username == usuario)
                    {
                        if (user.InvokeGet("PasswordExpirationDate") != null)
                        {
                            dt = (DateTime)user.InvokeGet("PasswordExpirationDate");
                            if (dt.Value.CompareTo(new DateTime(1970,1,1))==0)
                            {
                                //Password never expires
                                dt = null;
                            }
                        }
                        break;
                    }
                }
            }
            return dt;
        }
