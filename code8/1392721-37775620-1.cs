    bool IsSubclassOfGeneric(Type current, Type genericBase)
    {
        do 
        {
            if (current.IsGenericType && current.GetGenericTypeDefinition() == genericBase)
                return true;
        }
        while((current = current.BaseType) != null);
        return false;
    }
