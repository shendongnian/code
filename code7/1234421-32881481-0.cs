    foreach (var Type in TypeList)
    {
        foreach (string SingleType in TypeArray)
        {
            if (Type.Vaue.Equals(SingleType, StringComparison.InvariantCultureIgnoreCase))
            {
                IsValidType = true;
                break;
            }
        }
        if(IsValidType) break;
    }
