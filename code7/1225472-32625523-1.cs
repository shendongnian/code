    public static T ConvertTo<T>(this object value)
        {
            T returnValue = default(T);
            if (value is T)
            {
                returnValue = (T)value;
            }
            else
            {
                try
                {
                    returnValue = (T)Convert.ChangeType(value, typeof(T));
                }
                catch (InvalidCastException)
                {
                    returnValue = default(T);
                }
            }
            return returnValue;
        }
