    public static dynamic getDTO(object entity, string[] properties)
    {
        IDictionary<string, object> expando = new ExpandoObject();
    
        foreach (var p in properties)
        {
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(entity.GetType()))
            {
                if (property.Name == p)
                {
                    expando.Add(p, property.GetValue(entity));
                    break;
                }
            }
        }
        return expando as ExpandoObject;
    }
