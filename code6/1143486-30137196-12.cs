     public static class AssemblyExtensions
        {
            public static List<Type> FindAllDerivedTypes<T>(this Assembly assembly)
            {
                var derivedType = typeof(T);
                return assembly.GetTypes()
                              .Where(t => t != derivedType && derivedType.IsAssignableFrom(t))
                              .ToList();
    
            }
        }
