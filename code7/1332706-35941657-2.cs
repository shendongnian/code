    public static class ObjectHelper
    {
        public static T GetObjectToSerialize<T>(T value) 
        {
            foreach (var property in ObjectHelperInner<T>.Properties) 
            {
                property.SetValue(value, null, null);
            }
            return value;
        }
        private static class ObjectHelperInner<T>
        {
            public static readonly PropertyInfo[] Properties;
            static ObjectHelperInner()
            {
                PropertyInfo[] properties = typeof(T).GetProperties()
                                                        .Where(p => p.PropertyType == typeof(string))
                                                        .Where(p => p.Name.Contains("Password"))
                                                        .ToArray();
                var passwordWithoutEncryptedAttribute = properties
                            .Where(p => !p.GetCustomAttributes(typeof(EncryptedConfigurationItemAttribute), false).Any());
                if (passwordWithoutEncryptedAttribute.Any()) {
                    throw new InvalidOperationException(); // SafeFormatter.Format(BackgroundJobsLocalization.Culture, BackgroundJobsLocalization.PasswordWithoutEncryptedAttribute));
                }
                Properties = properties;
            }
        }
    }
