    public static class ValidationExtension
    {
        public static void ValidateObject<T>(this T obj) where T : INotifyErrorObject
        {
            if (obj == null)
                throw new ArgumentNullException("object to validate cannot be null");
            
            obj.ClearErrors();//clear all errors
            
            foreach (var item in GetProperties(obj))
            {
                obj.SetError(item.Name, string.Join(";", ValidateProperty(obj,item).ToArray())); //Set or remove error
            }
        }
        public static void ValidateProperty<T>(this T obj,string propName) where T : INotifyErrorObject
        {
            if (obj == null || string.IsNullOrEmpty(propName))
                throw new ArgumentNullException("object to validate cannot be null");
            var propertyInfo = GetProperty(propName, obj);
            if (propertyInfo != null)
            {
                obj.SetError(propertyInfo.Name, string.Join(";", ValidateProperty(obj,propertyInfo).ToArray())); //Set or remove error
            }
        }
        public static IEnumerable<string> ValidateProperty<T>(this T obj,PropertyInfo propInfo)
        {
            if (obj == null || propInfo == null)
                throw new ArgumentNullException("object to validate cannot be null");
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateProperty(propInfo.GetValue(obj), new ValidationContext(obj, null, null) { MemberName = propInfo.Name }, results))
                return results.Select(s => s.ErrorMessage);
            return Enumerable.Empty<string>();
        }
        static IEnumerable<PropertyInfo> GetProperties(object obj)
        {
            return obj.GetType().GetProperties().Where(p => p.GetCustomAttributes(typeof(ValidationAttribute), true).Length > 0).Select(p => p);
        }
        static PropertyInfo GetProperty(string propName, object obj)
        {
            return obj.GetType().GetProperties().FirstOrDefault(p =>p.Name==propName && p.GetCustomAttributes(typeof(ValidationAttribute), true).Length > 0);
        }
    }
