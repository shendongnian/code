    private static Type GetTypeFromTypeNameKey(TypeNameKey typeNameKey)
    {
        string assemblyName = typeNameKey.AssemblyName;
        string typeName = typeNameKey.TypeName;
        if (assemblyName != null)
        {
            // look, I don't like using obsolete methods as much as you do but this is the only way
            // Assembly.Load won't check the GAC for a partial name
            Assembly assembly = Assembly.LoadWithPartialName(assemblyName);
            if (assembly == null)
            {
                string partialName = assemblyName;
                var elements = assemblyName.Split(',');
                if (elements.Length > 0)
                {
                    partialName = elements[0];
                }
                // will find assemblies loaded with Assembly.LoadFile outside of the main directory
                Assembly[] loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (Assembly a in loadedAssemblies)
                {
                    if (a.GetName().Name == assemblyName || a.FullName == assemblyName || a.GetName().Name == partialName)
                    {
                        assembly = a;
                        break;
                    }
                }
            }
            if (assembly == null)
            {
                throw new JsonSerializationException(string.Format("Could not load assembly '{0}'.", assemblyName));
            }
            Type type = assembly.GetType(typeName);
            if (type == null)
            {
                throw new JsonSerializationException(string.Format("Could not find type '{0}' in assembly '{1}'.", typeName, assembly.FullName));
            }
            return type;
        }
        else if (typeName != null)
        {
            return Type.GetType(typeName);
        }
        else
        {
            return null;
        }
    }
