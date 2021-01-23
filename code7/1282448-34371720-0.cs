    var results = ActiveDirectory.GetUsers(filter);
    var userList = results.ToDictionary(result => result.ID);
    foreach (var result in results)
    {
        if (userList.ContainsKey(result.Manager))
        {
            userList[result.Manager].Employees.Add(result);
        }
    }
