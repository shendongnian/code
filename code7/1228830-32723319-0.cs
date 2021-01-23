    //Get the properties as a collection from the class
    Type tt = Type.GetType("TryReflection.Languages", true);
    PropertyDescriptorCollection props = TypeDescriptor.GetProperties(tt);  
  
    for (int i = 0; i < props.Count; i++)
    {
        PropertyDescriptor prop = props[i];
        string propertyInfo = String.Format("{0}: {1}", 
            prop.Name, 
            prop.PropertyType.GetGenericArguments()[0]));
        Console.Out.Write( propertyInfo );
    }
