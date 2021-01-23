    public static object GetProperty(this object instance, string name)
        {
            if (instance == null)
                throw new ArgumentNullException("instance");
            if (name == null)
                throw new ArgumentNullException("name");
            Type type = instance.GetType();
            PropertyInfo property = type.GetProperty(name, BindingFlags.Public | BindingFlags.Instance);
            if (property == null)
                throw new InvalidOperationException(string.Format("Type {0} does not have a property {1}", type, name));
            object result = property.GetValue(instance, null);
            return result;
        }
