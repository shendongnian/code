    List<Type> types = searchAssemblies
        .SelectMany(a => 
            a.GetTypes()
            .Where(myType => myType.IsClass && !myType.IsAbstract && HasGenericBase(myType, t))
        ).ToList();
    ...
    private static bool HasGenericBase(Type myType, Type t) {
        Debug.Assert(t.IsGenericTypeDefinition);
        while (myType != typeof(object)) {
            if (myType.IsGenericType && myType.GetGenericTypeDefinition() == t) {
                return true;
            }
            myType = myType.BaseType;
        }
        return false;
    }
