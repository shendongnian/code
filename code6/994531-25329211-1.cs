    public static class ConfigurationKeys
    {
        public static class Root
        {
            public static class Database
            {
                public static ConfigurationKey Host;
                public static ConfigurationKey Port;
                public static ConfigurationKey User;
            }
            public static class X
            {
                public static ConfigurationKey Enabled;
            }
            public static class Y
            {
                public static ConfigurationKey Enabled;
            }
        }
        public static void Build()
        {
            Build(typeof (ConfigurationKeys));
        }
        private static void Build(Type type)
        {
            var configurationKeyFields = type
                .GetFields()
                .Where(field => field.FieldType == typeof (ConfigurationKey));
            foreach (FieldInfo field in configurationKeyFields)
                field.SetValue(null, CreateConfigurationKey(type, field));
            var nestedClasses = type.GetNestedTypes().Where(nestedType => nestedType.IsClass);
            foreach (Type nestedClass in nestedClasses)
                Build(nestedClass.UnderlyingSystemType);
        }
        private static ConfigurationKey CreateConfigurationKey(Type type, FieldInfo field)
        {
            var parentPath = type.FullName.Substring(typeof (Root).FullName.Length + 1).Replace("+", "/");
            return new ConfigurationKey(parentPath + "/" + field.Name);
        }
    }
