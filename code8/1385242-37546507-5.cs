        public static void RegisterValidators(this IUnityContainer container)
        {
            var types = AllClasses.FromLoadedAssemblies().GetValidators();
            foreach (var type in types)
            {
                var interfaces = WithMappings.FromAllInterfaces(type);
                foreach (var @interface in interfaces)
                {
                    var myAttr = type.GetCustomAttributes<MyValidationAttribute>(false);
                    foreach (var attr in myAttr)
                    {
                        // Register with specific name.
                        container.RegisterType(@interface, type, attr.RegistrationName);
                    }
                }
            }
        }
