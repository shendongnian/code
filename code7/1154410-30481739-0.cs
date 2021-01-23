    Type type = Type.GetType("Namespace.Type, AssemblyName", false);
    if (type == null)
    {
        type = typeof(T);
    }
    object instance = Activator.CreateInstance(type);
