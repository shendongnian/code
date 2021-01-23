    //private static readonly Dictionary<Type, PropertyInfo[]> PasswordProperties = new Dictionary<Type, PropertyInfo[]>();
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> PasswordProperties = new ConcurrentDictionary<Type, PropertyInfo[]>();
    public static object GetObjectToSerialize(object value, Type targetType) {
        Type type = value.GetType();
        PropertyInfo[] properties;
        if (!PasswordProperties.TryGetValue(type, out properties)) 
        {
            properties = type.GetProperties()
                             .Where(p => p.PropertyType == typeof(string))
                             .Where(p => p.Name.Contains("Password"))
                             .ToArray();
            var passwordWithoutEncryptedAttribute = properties
                        .Where(p => !p.GetCustomAttributes(typeof(EncryptedConfigurationItemAttribute), false).Any());
            if (passwordWithoutEncryptedAttribute.Any()) {
                throw new InvalidOperationException(); // SafeFormatter.Format(BackgroundJobsLocalization.Culture, BackgroundJobsLocalization.PasswordWithoutEncryptedAttribute));
            }
            PasswordProperties[type] = properties;
        }
        foreach (var property in properties) 
        {
            property.SetValue(value, null, null);
        }
        return value;
    }
