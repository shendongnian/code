    foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (assembly.FullName.Contains("someNameYouCareAbout"))
                    {
                        builder.RegisterAssemblyTypes(assembly)
                       .AsImplementedInterfaces();
                    }
                }
