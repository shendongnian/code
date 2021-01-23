    List<string> userGroups = GetUserGroups();
    List<string> sqlGroups = GetSqlGroups();
    foreach (var sqlGroup in sqlGroups)
    {
        // case-sensitive check
        if (userGroups.Contains(sqlGroup))
        {
            // the user has one of the SQL groups
        }
        // case-insensitive check
        if (userGroups.Contains(sqlGroup, StringComparer.OrdinalIgnoreCase))
        {
            // the user has one of the SQL groups
        }
    }
