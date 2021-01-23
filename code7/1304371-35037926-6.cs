    public static class ObjectExtensions
    {
        public static void SetInheritedProperties(this object newClassIntance, object mainClassInstance)
        {
            var properties = mainClassInstance.GetType()
                .GetProperties();
    
            foreach (var propertyInfo in properties)
            {
                object value = propertyInfo.GetValue(mainClassInstance, null);
                
                if (null != value)
                    propertyInfo.SetValue(newClassIntance, value, null);
            }
        }
    }
