    public class DynamicMapper : IDynamicMapper
    {
        private readonly ILifetimeScope _scope;
        public DynamicMapper(ILifetimeScope scope)
        {
            this._scope = scope;
        }
        T IDynamicMapper.Extract<T>(object source)
        {
            // Get useful types
            Type sourceType = source.GetType();
            Type targetBaseType = typeof(TTarget);
            Type mapperBaseType = typeof(IMapper<,>).MakeGenericType(sourceType, targetBaseType);
            Type locatorType = typeof(IMapperLocator<>).MakeGenericType(sourceType);
            Type enumType = typeof(IEnumerable<>).MakeGenericType(locatorType);
            // Get all mapper implementations that take a TSource with the
            // same type as the source object
            var mappers = (IEnumerable<object>)this._scope.Resolve(enumType);
            // Among all the mappers with the right TSource, select the one
            // with TTarget assignable to T (throws if there is 0 or more than
            // one mapper, as this would be an implementation error)
            dynamic mapper = mappers.Single(x => mapperBaseType.IsAssignableFrom(x.GetType()));
            // The method must implemented implicitly.
            // A workaround would be to use a wrapper (IMapperWrapper<TSource, out TTarget>)
            // that implements the method implicitly and invokes the mapper's method
            // without using dynamic
            return mapper.Extract((dynamic)source);
        }
    }
