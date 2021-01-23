    Type t = parameters[i].GetType();
    if (t.IsGenericType)
    {
        Type typeArgument = t.GetGenericArguments()[0];
        ...
