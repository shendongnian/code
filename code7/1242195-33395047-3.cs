    public static class ReflectionToGetCurrentValuesExtension
    {
        public static Dictionary<string, object> GetValuesNow(this object obj)
        {
            var retVal = new Dictionary<string, object>();
            var type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.CanRead && property.CanWrite)
                {
                    if (!retVal.ContainsKey(property.Name))
                    {
                        retVal.Add(property.Name, property.GetValue(obj));
                    }
                }
            }
            return retVal;
        }
    }
