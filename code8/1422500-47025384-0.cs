    static int NonInheritedGenericParameterCount(this Type t)
    {
       return t.IsNested ? t.GenericParameterCount() - t.DeclaringType.GenericParameterCount()
                         : t.GetGenericParameterCount();
    }
