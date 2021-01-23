    var domainAndUsername = domain + @"\" + username;
    var entry = new DirectoryEntry(_path, domainAndUsername, pwd);
    object isValidPassword = null;
    try
    {
         // authenticate (check password)
         isValidPassword = entry.NativeObject;
    }
    catch (Exception ex)
    {
          _logger.Log.Debug($"LDAP Authentication Failed for {domainAndUsername}"); 
          return false;
    }
