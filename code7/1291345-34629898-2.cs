    using Ninject.Infrastructure.Language;
    public static void RegisterConstantAsAllTypes(IBindingRoot bindingRoot, object instance)
    {
        Type t = instance.GetType();
        IEnumerable<Type> typesToBind = t.GetAllBaseTypes()
            .Concat(t.GetInterfaces())
            .Except(new[] { typeof(object) });
        bindingRoot
            .Bind(typesToBind.ToArray())
            .ToConstant(instance);
    }
