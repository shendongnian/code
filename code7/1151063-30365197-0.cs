    Mapper.Initialize(cfg =>
    {
        // Here we're going to use some custom type converters
        // The custom converter just forces a cast between two somewhat castable types using implicit conversion.
        cfg.CreateMap<int, int?>().ConvertUsing<CastableTypeConverter<int, int?>>();
        cfg.CreateMap<double, int?>().ConvertUsing<CastableTypeConverter<double, int?>>();
        cfg.CreateMap<short, int?>().ConvertUsing<CastableTypeConverter<short, int?>>();
        cfg.CreateMap<byte, int?>().ConvertUsing<CastableTypeConverter<byte, int?>>();
        cfg.CreateMap<double, int>().ConvertUsing<CastableTypeConverter<double, int>>();
        cfg.CreateMap<decimal, int>().ConvertUsing<CastableTypeConverter<decimal, int>>();
        cfg.CreateMap<decimal, double>().ConvertUsing<CastableTypeConverter<decimal, double>>();
        cfg.CreateMap<short, int>().ConvertUsing<CastableTypeConverter<short, int>>();
        cfg.CreateMap<byte, int>().ConvertUsing<CastableTypeConverter<byte, int>>();
        /*...*/
    });
        
        
    /// <summary>
    /// This just forces implicit casting between two types (that are castable!)
    /// Such as (int) to (int?), or (double) to (int)
    /// </summary>
    /// <typeparam name="TSrc"></typeparam>
    /// <typeparam name="TDst"></typeparam>
    private class CastableTypeConverter<TSrc, TDst> : TypeConverter<TSrc, TDst>
    {
        protected override TDst ConvertCore(TSrc source)
        {
            Type srcType = typeof(TSrc);
            Type destType = typeof(TDst);
            TDst result = Activator.CreateInstance<TDst>();
            // a syntactical optimization
            object src = source;
            object dst = source;
            if (destType.IsGenericType && destType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                // get the underlying type
                destType = Nullable.GetUnderlyingType(destType);
            }
        
            // trying to cast to nullable type from non-nullable type,
            // or an implicit cast is required.
            if (destType == typeof(int) && srcType == typeof(decimal))
                dst = (int)(decimal)src;
            if (destType == typeof(int) && srcType == typeof(double))
                dst = (int)(double)src;
            if (destType == typeof(int) && srcType == typeof(float))
                dst = (int)(float)src;
            if (destType == typeof(int) && srcType == typeof(short))
                dst = (int)(short)src;
            if (destType == typeof(int) && srcType == typeof(byte))
                dst = (int)(byte)src;
            if (destType == typeof(int) && srcType == typeof(int))
                dst = (int)src;
        
        
        
            // now try to cast it appropriately
            try
            {
                result = (TDst)dst;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
