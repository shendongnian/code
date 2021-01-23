    public class LocalizedNullDisplayText : DisplayFormatAttribute
    {
        private readonly PropertyInfo _propertyInfo;
        public LocalizedNullDisplayText(string resourceKey, Type resourceType)
            : base()
        {
            _propertyInfo = resourceType.GetProperty(resourceKey, BindingFlags.Static | BindingFlags.Public);
            if (_propertyInfo == null) return;
            base.NullDisplayText = (string)_propertyInfo.GetValue(_propertyInfo.DeclaringType, null);
        }
    }
