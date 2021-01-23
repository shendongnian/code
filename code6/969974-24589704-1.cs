    Type dictType = typeof(IDictionary<,>);
    var icolIface = dictType.GetInterfaces()
                    .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICollection<>));
    
    Type colType = icolIface.GetGenericArguments()[0];
