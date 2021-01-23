    public static string GetTableName<T>()
            {
                var attr = Attribute.GetCustomAttributes(typeof (T), typeof (TableAttribute)).OfType<TableAttribute>().FirstOrDefault();
    
                if (attr != null)
                {
                    return attr.Name;
                }
    
                throw new Exception("Could not load TableAttribute of type" + typeof (T).Name);
            }
