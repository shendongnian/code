    public T ConvertClass<T>(X objectModel) 
    {
        Dictionary<string,string> columnMapping = new Dictionary<string,string>
        string valueTempplete = "'{value}'"
        foreach(var prop in objectModel.GetType().GetProperties(BindingFlags)) 
        {
            var propertyName = prop.Name;
            var value = objectModel.GetType().GetProperty(propertName).GetValue(objectModel, null).ToString();
            columnMapping.Add(propertyName, valueTemplete.Replace("{value}",value))
        }
    }
