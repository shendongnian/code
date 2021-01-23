    public static class Extensions
    {
        public static IEnumerable<T> Filter<T>(
            this IEnumerable<T> enumerable, string propertyName, object filterValue)
        {
            var elementType = typeof (T);
            var property = elementType.GetProperty(propertyName);
            
            return enumerable.Where(element =>
            {
                var propertyValue = property.GetMethod.Invoke(element, new object[] {});
                return propertyValue.Equals(filterValue);
            });
        }
    }
