    private static object Convert(string value, Type type)
        {
            object result;
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            try
            {
                var converter = TypeDescriptor.GetConverter(type);
                result = converter.ConvertFromString(value);
                return result;
            }
            catch (Exception exception)
            {
                // Log this exception if required.
                throw new InvalidCastException(string.Format("Unable to cast the {0} to type {1}", value, newType, exception));
            }
        }
