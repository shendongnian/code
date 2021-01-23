    public IEnumerable<object> ResolveAll(Type t, params ResolverOverride[] resolverOverrides)
    {
        var registrations = this.Registrations.Where(x => x.RegisteredType == t);
        foreach (var registration in registrations)
        {
            if(registration.Name != null)
                yield return this.Resolve(registration.RegisteredType, registration.Name, resolverOverrides)
        }
    }
