    var baseType = type.BaseType;
    while (baseType != null)
    {
        var attrs = baseType.GetCustomAttributes(typeof(TableBaseAttribute), false);
        if (attrs.Length > 0) 
        {
            ret = baseType.Name;
            break;
        }
    }
