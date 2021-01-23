    var mappers = typeFinder.FindClassesOfType(typeof(ICommonMapper<,,>)).ToList();
            foreach (var mapper in mappers)
            {
                builder.RegisterType(mapper)
                    .As(mapper.FindInterfaces((type, criteria) =>
                    {
                        var isMatch = type.IsGenericType &&
                                      ((Type)criteria).IsAssignableFrom(type.GetGenericTypeDefinition());
                        return isMatch;
                    }, typeof(ICommonMapper<,,>)))
                    .InstancePerLifetimeScope();
            }
