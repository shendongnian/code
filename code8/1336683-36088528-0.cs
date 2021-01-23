        private static void RegisterAssemblyInterfaces(List<Assembly> modulesAssemblies, ContainerBuilder builder)
        {
            var baseType = typeof (IPluginView);
            var pluginAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => baseType.IsAssignableFrom(p) && baseType != p);
            foreach (var assembly in pluginAssemblies)
            {
                var module = modulesAssemblies.FirstOrDefault(k => k.GetTypes().Any(v => v.IsAssignableFrom(assembly)));
                if (module == null) continue;
                var types = module.DefinedTypes.ToList();
                var interfaces = module.GetTypes().Where(k => k.IsInterface).ToList();
                if (!interfaces.Any()) continue;
                RegisterInterfaceToTypes(builder, interfaces, types);
            }
        }
        private static void RegisterInterfaceToTypes(ContainerBuilder builder, List<Type> interfaces, List<TypeInfo> types)
        {
            try
            {
                foreach (var @interface in interfaces)
                    foreach (var type in types.Where(type => @interface.IsAssignableFrom(type) && @interface != type))
                        builder.RegisterType(type).As(@interface).AsImplementedInterfaces();
            }
            catch
            {
                // ignored
            }
        }
