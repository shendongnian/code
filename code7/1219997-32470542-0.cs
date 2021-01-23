    public static Type[] GetDictionaryParameters(Type dicType) {
        foreach(var interf in dicType.GetInterfaces()) {
            if (interf.IsGenericType && interf.GetGenericTypeDefinition() == typeof(IDictionary<,>)) {
                return interf.GetGenericArguments();
            }
        }
        // No matching interface
        return null;
    }
