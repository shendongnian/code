    public string ToCSharpType(Type type)
    {
        if (!type.IsGeneric)
            return type.FullName;
        var result = new StringBuilder();
        string name = type.GetGenericTypeDefinition().FullName;
        result.Append(name.Substring(0, name.IndexOf('`'));
        result.Append('<');
        var args = type.GetGenericArguments();
        for (int i = 0; i < args.Length; i++)
        {
             result.Append(ToCSharpType(args[i]);
             if (i < args.Length - 1)
                 result.Append(", ");
        }
        result.Append('>');
    }
