    public bool VerifyPassword(string suppliedUserName, string suppliedPassword)
    {
        try
        {
            string dbPasswordHash = string.Empty;
            string salt = string.Empty;
            using (SqlDataReader reader = DB.drProc("LookupUser", new SqlParameter[] {
                DB.Parameter("@userName", SqlDbType.VarChar, 255, suppliedUserName) }))
            {
                reader.Read();
                dbPasswordHash = reader.GetString(0);
                salt = reader.GetString(1);
            }
            string passwordAndSalt = string.Concat(suppliedPassword, salt);
            string hashedPasswordAndSalt = FormsAuthentication.HashPasswordForStoringInConfigFile(passwordAndSalt, "SHA1");
            return hashedPasswordAndSalt.Equals(dbPasswordHash);
        }
        catch (Exception)
        {
            return false;
        }
    }
