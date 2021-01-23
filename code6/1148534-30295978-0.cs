    public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
    {
        if (value is string)
        {
            var source = (string)value;
            var sourceType = Type.GetType(source);
            if (sourceType != null && typeof(ISummarizable).IsAssignableFrom(sourceType))
            {
                var constructor = sourceType.GetConstructor(Type.EmptyTypes);
                var sourceInstance = constructor.Invoke(new object[0]);
                return sourceInstance;
            }
        }
        return base.ConvertFrom(context, culture, value);
    }
