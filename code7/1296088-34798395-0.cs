            var assemblies =
                AppDomain.CurrentDomain.GetAssemblies().Where(a => a.GetName().Name.Contains(".Infrastructure"));
            foreach (var assembly in assemblies)
            {
                var mapper = new ModelMapper();
                mapper.AddMappings(assembly.GetExportedTypes()
                    .Where(t => t.BaseType != null && t.BaseType.IsGenericType &&
                                t.BaseType.GetGenericTypeDefinition() == typeof (ClassMapping<>)));
                var compileMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
                compileMapping.autoimport = false;
                configuration.AddMapping(compileMapping);
            }
