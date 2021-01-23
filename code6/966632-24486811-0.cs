    private StaticOperator<T> GetValue<T>(T comparandValue)
    {
        Type type = typeof(T);
        if (type == typeof(int))
        {
            return GetIntVal(int.Parse(comparandValue.ToString()));
        }
        
        if (type == typeof(double))
        {
            return GetDoubleVal(double.Parse(comparandValue.ToString()));
        }
        if (type == typeof(string))
        {
            return GetStringVal(comparandValue.ToString());
        }
        if (type == typeof(DateTime))
        {
            return GetDateVal(comparandValue.ToString());
        }
        if (type == typeof(APIbject))
        {
            return GetObjectVal(comparandValue as APIObject);
        }
        throw new NotSupportedException("The given type is not supported");
    }
