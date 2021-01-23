    public static class ExtensionMethods
    {
        public static ExpandoObject ToExpando(this object obj)
        {
            IDictionary<string, object> expando = new ExpandoObject();
            foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(obj))
            {
                var value = propertyDescriptor.GetValue(obj);
                expando.Add(propertyDescriptor.Name, value == null || new[]
                {
                    typeof (Enum),
                    typeof (String),
                    typeof (Char),
                    typeof (Guid),
                    typeof (Boolean),
                    typeof (Byte),
                    typeof (Int16),
                    typeof (Int32),
                    typeof (Int64),
                    typeof (Single),
                    typeof (Double),
                    typeof (Decimal),
                    typeof (SByte),
                    typeof (UInt16),
                    typeof (UInt32),
                    typeof (UInt64),
                    typeof (DateTime),
                    typeof (DateTimeOffset),
                    typeof (TimeSpan),
                }.Any(oo => oo.IsInstanceOfType(value))
                    ? value
                    : value.ToExpando());
            }
            return (ExpandoObject)expando;
        }
    }
