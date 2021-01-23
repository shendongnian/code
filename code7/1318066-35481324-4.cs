    public class SimplePropertiesComparer<T> : Comparer<T>
    {
        public override int Compare (T x, T y)
        {
            Type type = typeof(T);
            var flags = BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance;
            foreach (var property in type.GetProperties(flags))
            {
                var propertyType = property.PropertyType;
                if (!typeof(IComparable).IsAssignableFrom(propertyType))
                   throw new NotSupportedException($"{propertyType} props are not supported.");
                var propertyValueX = (IComparable)property.GetValue(x);
                var propertyValueY = (IComparable)property.GetValue(y);
                if (propertyValueX == null && propertyValueY == null)
                    continue;
                if (propertyValueX == null)
                    return -1;
                int result = propertyValueX.CompareTo(property.GetValue(y));
                if (result == 0)
                    continue;
                return result;
            }
            return 0;
        }
    }
