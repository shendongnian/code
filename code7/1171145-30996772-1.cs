    var properties = typeof(TestTable).GetProperties();
    var attributesPerProperty = new Dictionary<string, string>();
    foreach (var propertyInfo in properties)
    {
        var attribute = System.Attribute.GetCustomAttributes(propertyInfo).FirstOrDefault();
                
        if(attribute is ColumnAttribute)
        {
            var columnAttribute = (ColumnAttribute)attribute;
            attributesPerProperty.Add(propertyInfo.Name, columnAttribute.DbType);
        }
    }
