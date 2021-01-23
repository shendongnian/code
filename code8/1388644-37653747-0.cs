    var type = inst.GetType();
    var result = false;
    while (type != typeof(object))
    {
        type = type.BaseType;
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(a<>))
        {
            result = true;
            break;
        }
    }
    //check result
