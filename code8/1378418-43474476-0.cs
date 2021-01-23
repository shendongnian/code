    private static bool LoginLdap(string username, string password)
        {
            try
            {
                using (var conn = new LdapConnection())
                {
                    conn.Connect("<LdapHost>", 389);
                    conn.Bind(LdapConnection.Ldap_V3, $"<yourDomain>\\{username}", password);
                }
                return true;
            }
            catch (LdapException)
            {
                return false;
            }
            //catch (System.IO.IOException)
            //{
            //    throw;
            //}
        }
