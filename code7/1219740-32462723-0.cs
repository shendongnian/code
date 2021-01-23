    foreach (Type type in assembly.GetTypes().Where(x => x.IsClass))
    {
        foreach (
            var @interface in
                type.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IConsume<>)))
        {
            kernel.Bind(@interface).To(type);
        }
    }
