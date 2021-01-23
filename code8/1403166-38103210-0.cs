    static bool Validate<T>(T obj)
    {
        var properties = obj.GetType().GetProperties().ToList();
    
        foreach(var prop in properties)
        {
            if(prop.IsDefined(typeof(RequiredAttribute)))
            {
                object value = prop.GetValue(obj);
                        
                if(value == null)
                {
                    // do something
                }
            }
                    
            if(prop.IsDefined(typeof(ContainsNumericAttribute)))
            {
    
            }
        }
    
        return false; // dummy value now
    }
