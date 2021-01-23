    using (ISession dynamicSession = pocoSession.GetSession(EntityMode.Map))
    {
        // Create a customer
        var frank = new Dictionary<string, object>();
        frank["name"] = "Frank";
        dynamicSession.Save("Customer", frank);
        ...
    }
    // Continue on pocoSession
