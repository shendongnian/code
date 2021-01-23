    public static class DynamicExtensions
    {
       public static IDictionary<string, object> ToDynamic(this object value)
        {
            IDictionary<string, object> expando = new ExpandoObject();
    
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(value.GetType()))
                expando.Add(property.Name, property.GetValue(value));
    
            return expando;
        }
    }
