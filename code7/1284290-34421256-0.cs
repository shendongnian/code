        public static void CopyNotNulls<T>(T source, T dest)
        {
            var type = typeof(T);
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType.IsClass)
                .ToArray();
            foreach (var property in properties)
            {
                var val = property.GetValue(source);
                if (val == null)
                {
                    continue;
                }
                property.SetValue(dest, val);
            }
        }
