    public static object ToObject(Type type, string value)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            if (!typeof (IConvertible).IsAssignableFrom(type))
            {
                if (type.IsGenericType)
                {
                    Type converterType = typeof (CustomConverter<>).MakeGenericType(type);
                    Type genericConverter =
                        typeof (ICustomConverter).Assembly.Types(Flags.Public)
                            .SingleOrDefault(
                                t =>
                                    typeof (ICustomConverter).IsAssignableFrom(t) && t.IsGenericType &&
                                    t.GetGenericArguments().Length == type.GetGenericArguments().Length && !t.IsAbstract &&
                                    t.MakeGenericType(type.GetGenericArguments()).IsSubclassOf(converterType));
                    if (genericConverter != null)
                    {
                        Type customConverter = genericConverter.MakeGenericType(type.GetGenericArguments());
                        object instance = customConverter.CreateInstance();
                        if (instance is ICustomConverter)
                            return ((ICustomConverter) instance).CallConvert(value);
                    }
                }
                else
                {
                    Type converterType = typeof (CustomConverter<>).MakeGenericType(type);
                    Type customConverter =
                        typeof (ICustomConverter).Assembly.Types(Flags.Public)
                            .SingleOrDefault(t => t.IsSubclassOf(converterType));
                    if (customConverter != null)
                    {
                        object instance = customConverter.CreateInstance();
                        if (instance is ICustomConverter)
                            return ((ICustomConverter) instance).CallConvert(value);
                    }
                }
    
    
                throw new ArgumentException("type is not IConvertible and no custom converters found", type.Name());
            }
            TypeConverter converter = TypeDescriptor.GetConverter(type);
            return converter.ConvertFromString(value);
        }
