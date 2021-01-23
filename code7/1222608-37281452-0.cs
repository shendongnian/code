    public TDestination Map<TDestination>(object source, Action<IMappingOperationOptions> opts)
        {
            var mappedObject = default(TDestination);
            if (source != null)
            {
                var sourceType = source.GetType();
                var destinationType = typeof(TDestination);
    
                mappedObject = (TDestination)Map(source, sourceType, destinationType, opts);
            }
            return mappedObject;
        }
