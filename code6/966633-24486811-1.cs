    private StaticOperator<T> GetValue<T>(T comparandValue)
    {
        Type type = typeof(T);
        if (type == typeof(int))
        {
            return GetIntVal((dynamic)comparandValue);
        }
        
        if (type == typeof(double))
        {
            return GetDoubleVal((dynamic)comparandValue);
        }
        if (type == typeof(string))
        {
            return GetStringVal((dynamic)comparandValue);
        }
        if (type == typeof(DateTime))
        {
            return GetDateVal((dynamic)comparandValue);
        }
        if (type == typeof(APIbject))
        {
            return GetObjectVal(comparandValue as APIObject);
        }
        throw new NotSupportedException("The given type is not supported");
    }
