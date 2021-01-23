    Type baseType = typeof(... someting ...);
    Assembly assembly = ... your assembly ...;
            
    foreach (Type type in assembly.GetTypes())
    {
        // If type implements/subclasses baseType
        if (baseType.IsAssignableFrom(type))
        {
            // If there is a public parameterless constructor
            if (type.GetConstructor(Type.EmptyTypes) != null)
            {
                IMyInterface obj = (IMyInterface)Activator.CreateInstance(type)
            }
        }
    }
