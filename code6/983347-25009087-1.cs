    return assembly.DefinedTypes
                   .Where(t => interfaceType.IsAssignableFrom(t))
                   .Select(t => Activator.CreateInstance(t))
                   .Cast<TInterface>()
                   .ToList();
