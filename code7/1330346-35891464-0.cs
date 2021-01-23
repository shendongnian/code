    public class CustomNotEmpty<T> : PropertyValidator
    {
        private PropertyInfo _propertyInfo;
        public CustomNotEmpty(PropertyInfo propertyInfo)
            : base(string.Format("{0} is required", propertyInfo.Name))
        {
            _propertyInfo = propertyInfo;
        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            return !IsNullOrEmpty(_propertyInfo, (T)context.Instance);
        }
        private bool IsNullOrEmpty(PropertyInfo property, T obj)
        {
            var t = property.PropertyType;
            var v = property.GetValue(obj);
            // Omitted for clarity...
        }
    }
