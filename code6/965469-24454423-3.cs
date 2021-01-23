    public static void ForwardOpenGenericTo(this Container container,
        Type openGenericServiceType, Type openGenericServiceTypeToForwardTo)
    {
        container.ResolveUnregisteredType += (s, e) =>
        {
            var type = e.UnregisteredServiceType;
            if (type.IsGenericType)
            {
                if (type.GetGenericTypeDefinition() == openGenericServiceType)
                {
                    var forwardToType = openGenericServiceTypeToForwardTo.MakeGenericType(
                        type.GetGenericArguments());
                    var producer = container.GetRegistration(forwardToType, true);
                    e.Register(producer.Registration);
                }
            }
        };
    }
