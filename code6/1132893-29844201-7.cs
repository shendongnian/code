    builder.RegisterGeneric(typeof(DefaultFactory<>))
            .As(typeof(IFooFactory<>))
            .OnActivating(e =>
            {
                Type elementType = e.Instance.GetType().GetGenericArguments()[0];
                Type fooFactoryType = typeof(IFooFactory<>).MakeGenericType(elementType); 
                Service service = new KeyedService(elementType.Namespace, fooFactoryType);
                Object fooFactory = e.Context.ResolveOptionalService(service, e.Parameters);
                if (fooFactory != null)
                {
                    e.ReplaceInstance(fooFactory);
                }
            });
