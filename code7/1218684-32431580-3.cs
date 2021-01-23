    if (property.PropertyType.Name.ToLower() == "list`1")
    {
        IList users = property.GetValue(MyClass, null) as IList;
        // users is the required list of users of Team, now loop for each user to get their Id and save to database.
        foreach (var user in users)
        {
            //do work with user here ...
        }
    }
