    if (e.Control is IContract)
    {
        // Gets all the IContract<> interfaces e.Control implements:
        var generics = GetIContractGenerics(e.Control.GetType());
        // There might be multiple IContract<> implementations
        // so therefore we need to check them all, even though in
        // practice there will likely only be a single instance:
        foreach (var generic in generics)
        {
            var method = this.GetType().GetMethod(
                "SubscribeToContract", (BindingFlags.Instance | BindingFlags.NonPublic));
            method = method.MakeGenericMethod(generic);
            var result = method.Invoke(this, new[] { e.Control });
        }
    }
