    public static class LocalExtensions
    {
        public static object GetPrivatePropertyValue(this object obj, string propName)
        {
            PropertyInfo pi = obj.GetType().GetProperty(propName, BindingFlags.Public 
                                            | BindingFlags.NonPublic | BindingFlags.Instance);
            return pi.GetValue(obj, null);
        }
        public static object GetPrivateFieldValue(this object obj, string fieldName)
        {
            FieldInfo pi = obj.GetType().GetField(fieldName, BindingFlags.Public 
                                         | BindingFlags.NonPublic | BindingFlags.Instance);
            return pi.GetValue(obj);
        }
    }
