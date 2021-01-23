    public class EmtpyEnumerables : ReflectionVisitor<object>
    {
        private object value;
        public EmtpyEnumerables(object value)
        {
            this.value = value;
        }
        public override object Value
        {
            get { return value; }
        }
        public override IReflectionVisitor<object> Visit(PropertyInfoElement propertyInfoElement)
        {
            var pi = propertyInfoElement.PropertyInfo;
            if (pi.PropertyType.IsConstructedGenericType && 
                pi.PropertyType.GetGenericTypeDefinition() == typeof(IEnumerable<>) &&
                pi.CanWrite)
            {
                var elementType = pi.PropertyType.GetGenericArguments().Single();
                pi.SetValue(value, Array.CreateInstance(elementType, 0));
                return this;
            }
            return base.Visit(propertyInfoElement);
        }
    }
