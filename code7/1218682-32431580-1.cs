    if (property.PropertyType.Name.ToLower() == "list`1")
    {
        IList users = property.GetValue(MyClass, null) as IList;
        foreach (var user in users)
        {
            //do work with user here ...
        }
    }
