     Example obj = new Example();
     Type type = obj.GetType();
     PropertyInfo[] properties = type.GetProperties();
     double d = 0.1;
     foreach (PropertyInfo property in properties)
     {           
          property.SetValue(obj, d, null);               
     }
