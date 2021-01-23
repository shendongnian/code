    public string GetNameOfInnerT()
    {
        Type type = typeof(T);
        if (type.IsGenericType) {
            // TODO: what if more than one generic arguments???
            return type.GetGenericArguments()[0].Name;
        }
        // TODO: return null, empty string or throw exception
    }
