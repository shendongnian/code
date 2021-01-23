    List<string> userGroups = GetUserGroups();
    List<string> sqlGroups = GetSqlGroups();
    foreach (var sqlGroup in sqlGroups)
    {
        if (userGroups.Contains(sqlGroup))
        {
            // the user has one of the SQL groups
        }
    }
