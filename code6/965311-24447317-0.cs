    Type type = p.ParameterType;
    if(type.IsByRef)
    {
        Type actualType = type.GetElementType();
        // ...
    }
    else
    {
        // ...
    }
