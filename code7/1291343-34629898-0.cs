    public static void RegisterConstantAsAllTypes(IBindingRoot bindingRoot, object instance)
    {
        Type t = instance.GetType();
        // GetAllBaseTypes requires using Ninject.Infrastructure.Language;
        IEnumerable<Type> typesToBind = t.GetAllBaseTypes()
                                            .Concat(t.GetInterfaces());
        bindingRoot
            .Bind(typesToBind.ToArray())
            .ToConstant(instance);
    }
