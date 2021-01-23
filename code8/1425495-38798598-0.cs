        public static T GetEnumDisplayNameValue<T>(this string name, CultureInfo culture)
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException();
            FieldInfo[] fields = type.GetFields();
            var field = fields.SelectMany(f => f.GetCustomAttributes(typeof(DisplayAttribute), false),
                (f, a) => new { Field = f, Att = a })
                .SingleOrDefault(a => Resources.ResourceManager.GetString(((DisplayAttribute)a.Att).Name, culture) == name);
            return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
        }
