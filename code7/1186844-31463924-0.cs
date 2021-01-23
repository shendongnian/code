        public static List<T> GetAllDerivedTypes<T>(this Assembly assembly)
        {
            var type = typeof(T);
            var isInterface = type.IsInterface;
            if (!isInterface)
            {
                throw new Exception("Not an interface type");
            }
            return assembly
                        .DefinedTypes
                        .Where(x => type.IsAssignableFrom(x) && !x.IsInterface)
                        .Select(Activator.CreateInstance)
                        .Cast<T>()
                        .ToList();
        }
