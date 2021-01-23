    void DisplayContainerRegistrations(IUnityContainer theContainer)
    {
        string regName, regType, mapTo, lifetime;
        Console.WriteLine("Container has {0} Registrations:",
                theContainer.Registrations.Count());
        foreach (ContainerRegistration item in theContainer.Registrations)
        {
        regType = item.RegisteredType.Name;
        mapTo = item.MappedToType.Name;
        regName = item.Name ?? "[default]";
        lifetime = item.LifetimeManagerType.Name;
        if (mapTo != regType)
        {
            mapTo = " -> " + mapTo;
        }
        else
        {
            mapTo = string.Empty;
        }
        lifetime = lifetime.Substring(0, lifetime.Length - "LifetimeManager".Length);
        Console.WriteLine("+ {0}{1}  '{2}'  {3}", regType, mapTo, regName, lifetime);
        }
    }
