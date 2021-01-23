    IList<Type> matchingTypes = new List<Type>();
    foreach(Assembly a in AppDomain.CurrentDomain.GetAssemblies()) {
        // Skip dynamic assemblies.
        if (a.GetType().StartsWith("System.Reflection.Emit.")) {
            continue;
        }
        Type t = a.GetType(classNameWithNameSpace);
        if (t != null) {
            matchingTypes.Add(t);
        }
    }
