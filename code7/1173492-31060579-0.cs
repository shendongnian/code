    public static class ObjectExtensions
        {
            public static void SetValue(this object self, string name, object value)
            {
                PropertyInfo propertyInfo = self.GetType().GetProperty(name);
                propertyInfo.SetValue(self, Convert.ChangeType(value, propertyInfo.PropertyType), null);
            }
            public static void SetValues(this object self, NameValueCollection nameValues) {
    
                foreach (var item in nameValues.AllKeys)
                {
                    SetValue(self, item, nameValues[item]);
                }
            }
        }
