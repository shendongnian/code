    var queryParams = new DynamicParameters();
    foreach (var kvp in paramDict)
    {
        var enumParam = kvp.Value as Enum;
        if (enumParam == null)
        {
            queryParams.Add(kvp.key, kvp.Value);
        }
        else
        {
            queryParams.Add(kvp.key, new EnumParameter(enumParam));
        }
    }
