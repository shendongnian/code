    Type implementation = Assembly
            .LoadFrom(fileName)
            .GetExportedTypes()
            .Where(t => 
                typeof(IExample).IsAssignableFrom(t) && 
                !t.IsAbstract &&
                !t.IsGenericType &&
                t.GetConstructors(BindingFlags.Public).Any(c => !c.GetParameters().Any())
            .FirstOrDefault();
