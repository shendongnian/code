        public static TResult CastTo<TResult>(this object arg)
        {
            TypeConverter typeConverter = TypeDescriptor.GetConverter(arg.GetType());
            bool? converter = typeConverter.CanConvertTo(typeof(TResult));
            if (converter != null && converter == true)
                return (TResult)typeConverter.ConvertTo(arg, typeof(TResult));
            else
                return default(TResult);
        }
