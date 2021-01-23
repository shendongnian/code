    foreach (Type t in typeof(Program).Assembly
                                        .GetLoadableTypes()
                                        .Where(t => t.GetInterfaces()
                                                    .Any(i => i.IsGenericType 
                                                            && i.GetGenericTypeDefinition() == typeof(IUploadStrategy<,>))))
    {
        builder.RegisterGeneric(t).As(typeof(IUploadStrategy<,>));
    }
