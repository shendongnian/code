    private NameValueCollection ObjectToCollection(object objects)
    {
    NameValueCollection parameter = new NameValueCollection();
    Type type = objects.GetType();
    PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance |
                                                    BindingFlags.DeclaredOnly |
                                                    BindingFlags.Public);
    foreach (PropertyInfo property in properties)
    {
        if (property.PropertyType == typeof(MetaTags))
        {
                parameter.Add(property.Name.ToString(),ObjectToCollection(property.GetValue(objects, null)))
        }
        else{
        if (property.GetValue(objects, null) == null)
        {
            parameter.Add(property.Name.ToString(), "");
        }
        else
        {
            if (property.GetValue(objects, null).ToString() != "removeProp")
            {
                parameter.Add(property.Name.ToString(), property.GetValue(objects, null).ToString());
            }
        }
        }
    }
    return parameter;
    }
