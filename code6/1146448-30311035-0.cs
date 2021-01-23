    static void Assign(IDataReader reader, object instance) {
            foreach (PropertyInfo prop in PropertyInfo)
            {
                if (IsValue(prop))
                {
                    prop.SetValue(obj, dataReader[prop.Name], null);
                }
                else if (IsClass(prop)) {
                   var subInstance = Activator.CreateInstance(prop.PropertyType);
                    prop.SetValue(obj, subInstance, null);
                   Assign(subInstance, dataReader);
                }
            }
    }
