    static bool IsGenericInstance(this Type t, Type genTypeDef, params Type[] args) {
        if (!t.IsGenericType) return false;
        if (t.GetGenericTypeDefinition() != genTypeDef) return false;
        var typeArgs = t.GetGenericArguments();
        if (typeArgs.Length != args.Length) return false;
        // Go through the arguments passed in, interpret nulls as "any type"
        for (int i = 0 ; i != args.Length ; i++) {
            if (args[i] == null) continue;
            if (args[i] != typeArgs[i]) return false;
        }
        return true;
    }
