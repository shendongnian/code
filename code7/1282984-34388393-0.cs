    Func<Type, Type, bool> checkTypesEqual = null;
    checkTypesEqual = (t1, t2) =>
    {
        if (t1.IsGenericParameter || t2.IsGenericParameter) // <-------
            return true;
        if (t1.IsGenericType && t2.IsGenericType)
        {
            if (t1.GetGenericTypeDefinition() != t2.GetGenericTypeDefinition())
                return false;
            var t1args = t1.GetGenericArguments();
            var t2args = t2.GetGenericArguments();
            if (t1args.Length != t2args.Length)
                return false;
            for (int i = 0; i < t1args.Length; i++)
            {
                if (!checkTypesEqual(t1args[i], t2args[i]))
                    return false;
            }
            return true;
        }
        return t1 == t2;
    };
