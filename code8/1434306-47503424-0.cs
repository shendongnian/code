        public static class Mapping
    {
        public static void Initialize()
        {
            // Or marker types for assemblies:
            Mapper.Initialize(cfg =>
                cfg.AddProfiles(new[] {
                    typeof(MapperFromImportedAssemblyA),
                    typeof(MapperFromImportedAssemblyB),
                    typeof(MapperFromImportedAssemblyC)
                })
                );
        }
    }
