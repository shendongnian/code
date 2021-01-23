    Type type = obj.GetType();
    PropertyInfo[] properties = type.GetProperties();
    
    foreach (PropertyInfo property in properties)
    {
        GetColumn(orgList,property.Name); 
    }
    var names = items.Select(x => x.GetType().GetProperty("prpname").GetValue(x));
    public IEnumerable<object> GetColumn(List<Item> items, string columnName)
    {
        var values = items.Select(x => 
    x.GetType().GetProperty(columnName).GetValue(x));//u can put your test code heere and you can loop it through object properties
    }
