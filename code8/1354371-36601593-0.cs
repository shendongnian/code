    modelBuilder.Types().Configure((entityConfiguration) =>
                    {                    
                        const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly;                    
                        foreach (var propertyInfo in entityConfiguration.ClrType.GetProperties(bindingFlags))
                        {
                            var attributes = propertyInfo.GetCustomAttributes(inherit: false);
                            var fieldAttribute = attributes.FirstOrDefault(x => x.GetType() == typeof(FieldAttribute) || x.GetType() == typeof(KeyAttribute));
                            if (fieldAttribute == null)
                            {
                                entityConfiguration.Ignore(propertyInfo);
                            }
                        }
                    });
