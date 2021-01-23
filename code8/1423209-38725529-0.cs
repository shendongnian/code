        public static MetaType AddTypeToModel<T>(RuntimeTypeModel typeModel)
        {
            var properties = typeof(T)
                .GetProperties()
                .Where(p => !p.GetCustomAttributes<ProtoIgnoreAttribute>().Any())
                .Select(p => p.Name)
                .OrderBy(name => name);
            return typeModel.Add(typeof(T), true).Add(properties.ToArray());
        }
