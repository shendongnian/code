    public static class ObjectExtensions
    {
        public static void SetInheritedProperties(this object newClassIntance, object mainClassInstance)
        {
            foreach (PropertyInfo propertyInfo in mainClassInstance.GetType().GetProperties())
            {
                object value = propertyInfo.GetValue(mainClassInstance, null);
                if (null != value) propertyInfo.SetValue(newClassIntance, value, null);
            }
        }
    }
