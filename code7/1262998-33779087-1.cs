    var table = (IEnumerable)context.GetType().GetProperty(tableName).GetValue(context, null);
    List<object> results = new List<object>();
    foreach(var line in table)
    {
        var value = line.GetType().GetProperty(propertyName).GetValue(line, null);
        if(value == searchValue) {
            results.Add(line);
        }
    }
